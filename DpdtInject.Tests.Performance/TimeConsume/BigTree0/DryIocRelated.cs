//seed: -624853138
using DpdtInject.Injector;
using DpdtInject.Injector.Excp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DryIoc;

namespace DpdtInject.Tests.Performance.TimeConsume.BigTree0
{
    public static class DryIocRelated
    {
        public const int BindCount = 10;
        public const string BindCountString = "10";
        public const string GenericTestName = "GenericSingleton10";
        public const string NonGenericTestName = "NonGenericSingleton10";
        public static void Bind(Container container)
        {
#region bind code
            container.Register<IInterface0, Class0>(Reuse.Singleton);
            container.Register<IInterface1, Class1>(Reuse.Singleton);
            container.Register<IInterface2, Class2>(Reuse.Singleton);
            container.Register<IInterface3, Class3>(Reuse.Singleton);
            container.Register<IInterface4, Class4>(Reuse.Singleton);
            container.Register<IInterface5, Class5>(Reuse.Singleton);
            container.Register<IInterface6, Class6>(Reuse.Singleton);
            container.Register<IInterface7, Class7>(Reuse.Singleton);
            container.Register<IInterface8, Class8>(Reuse.Singleton);
            container.Register<IInterface9, Class9>(Reuse.Singleton);
            ;
#endregion
        }

#region resolution code
        public static void ResolveGeneric(Container container)
        {
            var resolvedInstance0 = container.Resolve<IInterface0>();
            var resolvedInstance1 = container.Resolve<IInterface1>();
            var resolvedInstance2 = container.Resolve<IInterface2>();
            var resolvedInstance3 = container.Resolve<IInterface3>();
            var resolvedInstance4 = container.Resolve<IInterface4>();
            var resolvedInstance5 = container.Resolve<IInterface5>();
            var resolvedInstance6 = container.Resolve<IInterface6>();
            var resolvedInstance7 = container.Resolve<IInterface7>();
            var resolvedInstance8 = container.Resolve<IInterface8>();
            var resolvedInstance9 = container.Resolve<IInterface9>();
            ;
        }

        public static void ResolveNonGeneric(Container container)
        {
            var resolvedInstance0 = container.Resolve(typeof(IInterface0));
            var resolvedInstance1 = container.Resolve(typeof(IInterface1));
            var resolvedInstance2 = container.Resolve(typeof(IInterface2));
            var resolvedInstance3 = container.Resolve(typeof(IInterface3));
            var resolvedInstance4 = container.Resolve(typeof(IInterface4));
            var resolvedInstance5 = container.Resolve(typeof(IInterface5));
            var resolvedInstance6 = container.Resolve(typeof(IInterface6));
            var resolvedInstance7 = container.Resolve(typeof(IInterface7));
            var resolvedInstance8 = container.Resolve(typeof(IInterface8));
            var resolvedInstance9 = container.Resolve(typeof(IInterface9));
            ;
        }
#endregion
    }
}