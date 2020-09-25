﻿using DpdtInject.Generator.Helpers;
using DpdtInject.Generator.Producer.Blocks.Binding;
using DpdtInject.Generator.Producer.Blocks.Binding.InstanceContainer;
using DpdtInject.Generator.Producer.Blocks.Cluster;
using DpdtInject.Generator.Properties;
using DpdtInject.Injector.Helper;
using DpdtInject.Injector.Module.Bind;
using DpdtInject.Injector.Module.RContext;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdtInject.Generator.Parser.Binding
{
    [DebuggerDisplay("{BindFromTypes[0].Name} -> {TargetRepresentation}")]
    public class BindingContainerWithInstance : BaseBindingContainer
    {
        public override IReadOnlyList<DetectedConstructorArgument> ConstructorArguments
        {
            get;
        }

        public override IReadOnlyCollection<ITypeSymbol> NotBindConstructorArgumentTypes
        {
            get;
        }

        public override string TargetRepresentation
        {
            get
            {
                if(IsRootCluster)
                {
                    return BindToType.GetFullName();
                }

                return DeclaredClusterType!.GetFullName() + " : " + BindToType.GetFullName();
            }
        }


        public BindingContainerWithInstance(
            ITypeSymbol declaredClusterType,
            IReadOnlyList<ITypeSymbol> bindFromTypes,
            ITypeSymbol bindToType,
            IReadOnlyList<DetectedConstructorArgument> constructorArguments,
            BindScopeEnum scope,
            ArgumentSyntax? whenArgumentClause
            ) : base(declaredClusterType, bindFromTypes, bindToType, scope, whenArgumentClause)
        {
            if (constructorArguments is null)
            {
                throw new ArgumentNullException(nameof(constructorArguments));
            }

            ConstructorArguments = constructorArguments;
            NotBindConstructorArgumentTypes = new HashSet<ITypeSymbol>(constructorArguments.Where(ca => !ca.DefineInBindNode).Select(ca => ca.Type!), new TypeSymbolEqualityComparer());
        }

        public override string PrepareInstanceContainerCode(
            ClusterGeneratorTreeJoint clusterGeneratorJoint
            )
        {
            if (clusterGeneratorJoint is null)
            {
                throw new ArgumentNullException(nameof(clusterGeneratorJoint));
            }

            GetInstanceContainerBody(out var className, out var resource);

            var cus = SyntaxFactory.ParseCompilationUnit(resource);
            var cds = cus.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var instanceContainerCode = cds.GetText().ToString();

            var result = instanceContainerCode
                .CheckAndReplace(className, GetContainerStableClassName())
                .CheckAndReplace(nameof(FakeTarget), BindToType.GetFullName())
                .CheckAndReplace(
                    "//GENERATOR: argument methods",
                    string.Join(
                        Environment.NewLine,
                        ConstructorArguments
                            .Where(ca => !ca.DefineInBindNode)
                            .Select(ca => ca.GenerateProvideConstructorArgumentMethod(clusterGeneratorJoint, this)
                            )
                        )
                    )
                .CheckAndReplace(
                    "//GENERATOR: apply arguments",
                    string.Join(
                        ",",
                        ConstructorArguments
                            .Select(ca => ca.GetApplyConstructorClause())
                            .RemoveAll(ca => string.IsNullOrEmpty(ca))
                        )
                    )
                .CheckAndReplace("//GENERATOR: predicate", (WhenArgumentClause?.ToString() ?? "rc => true"))
                ;

            return result;
        }
    }
}
