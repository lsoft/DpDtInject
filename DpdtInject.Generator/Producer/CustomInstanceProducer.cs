﻿using DpdtInject.Generator.ArgumentWrapper;
using DpdtInject.Generator.Binding;
using DpdtInject.Generator.Helpers;
using DpdtInject.Generator.TypeInfo;
using DpdtInject.Injector;
using DpdtInject.Injector.Helper;
using System;
using DpdtInject.Generator.Producer.Product;

namespace DpdtInject.Generator.Producer
{
    internal class CustomInstanceProducer : IInstanceProducer

    {
        private readonly ITypeInfoProvider _typeInfoProvider;
        private readonly ClusterBindings _clusterBindings;
        private readonly BindingContainerExtender _bindingExtender;

        public CustomInstanceProducer(
            ITypeInfoProvider typeInfoProvider,
            ClusterBindings clusterBindings,
            BindingContainerExtender bindingExtender
            )
        {
            if (typeInfoProvider is null)
            {
                throw new ArgumentNullException(nameof(typeInfoProvider));
            }

            if (clusterBindings is null)
            {
                throw new ArgumentNullException(nameof(clusterBindings));
            }

            if (bindingExtender is null)
            {
                throw new ArgumentNullException(nameof(bindingExtender));
            }
            _typeInfoProvider = typeInfoProvider;
            _clusterBindings = clusterBindings;
            _bindingExtender = bindingExtender;
        }

        public InstanceProduct Produce()
        {
            var constructorArgumentProducers =
                _bindingExtender.BindingContainer.ConstructorArguments.ConvertAll(
                    bft => new ConstructorArgumentProducer(
                        _clusterBindings,
                        _bindingExtender,
                        bft
                        )
                    );

            var (caps, utps) = constructorArgumentProducers.Produce();

            IMethodProduct? predicateMethod = null;
            if (_bindingExtender.BindingContainer.IsConditional)
            {
                predicateMethod = MethodProductFactory.Create(
                    $"CheckPredicate_{_bindingExtender.BindingContainer.BindToType.Name}_{_bindingExtender.BindingContainer.GetStableSuffix()}",
                    new TypeMethodResult(_typeInfoProvider.Bool()),
                    (methodName, returnType) => $@"
[MethodImpl(MethodImplOptions.AggressiveInlining)]
private {returnType} {methodName}(IResolutionTarget resolutionTarget)
{{
    Func<IResolutionTarget, bool> predicate = 
        {_bindingExtender.BindingContainer.WhenArgumentClause}
        ;

    var result = predicate(resolutionTarget);
    return result;
}}
");
            }

            var scopeGuidName = $"_customScopeUniqueId_{_bindingExtender.BindingContainer.BindToType.Name}_{_bindingExtender.BindingContainer.GetStableSuffix()}";

            var retrieveObjectMethod = MethodProductFactory.Create(
                $"GetInstance_{_bindingExtender.BindingContainer.BindToType.Name}_{_bindingExtender.BindingContainer.GetStableSuffix()}",
                new TypeMethodResult(_bindingExtender.BindingContainer.BindToType),
                (methodName, returnType) => $@"
private readonly System.Guid {scopeGuidName} = new System.Guid(""{Guid.NewGuid()}"");

[MethodImpl(MethodImplOptions.AggressiveInlining)]
private {returnType} {methodName}(
    IResolutionTarget resolutionTarget
    )
{{
    if(resolutionTarget.ScopeObject is null)
    {{
        RaiseNoCustomScopeObject<{_bindingExtender.BindingContainer.BindToType.ToDisplayString()}>();
    }}

    var result = ({_bindingExtender.BindingContainer.BindToType.ToDisplayString()}) resolutionTarget.ScopeObject.GetOrAdd(
        {scopeGuidName},
        () => new {_bindingExtender.BindingContainer.BindToType.ToDisplayString()}(
            {caps.Join(p => p.ResolveConstructorArgumentClause, ",")}
            )
        );

    return result;
}}
");

            var funcMethod = MethodProductFactory.Create(
                $"GetInstance_{_bindingExtender.BindingContainer.BindToType.Name}_{_bindingExtender.BindingContainer.GetStableSuffix()}{DpdtArgumentWrapperTypeEnum.Func.GetPostfix()}",
                new TypeMethodResult(_typeInfoProvider.Func(_bindingExtender.BindingContainer.BindToType)),
                (methodName, returnType) => $@"
[MethodImpl(MethodImplOptions.AggressiveInlining)]
private {returnType} {methodName}(
    IResolutionTarget resolutionTarget
    )
{{
    return () => {retrieveObjectMethod.GetWrappedMethodName(DpdtArgumentWrapperTypeEnum.None)}(resolutionTarget);
}}
");


            var product = new InstanceProduct(
                _bindingExtender,
                predicateMethod,
                retrieveObjectMethod,
                funcMethod,
                null,
                utps
                );

            return product;
        }
    }
}
