//seed: -624853138
using DpdtInject.Injector;
using DpdtInject.Injector.Excp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public const int BindCount = 50;
        public const string BindCountString = "50";
        public const string TestPrefix = "GenericTransient50";
        public static void Bind(Container container)
        {
#region bind code
            container.Register<IInterface0, Class0>(Reuse.Transient);
            container.Register<IInterface1, Class1>(Reuse.Transient);
            container.Register<IInterface2, Class2>(Reuse.Transient);
            container.Register<IInterface3, Class3>(Reuse.Transient);
            container.Register<IInterface4, Class4>(Reuse.Transient);
            container.Register<IInterface5, Class5>(Reuse.Transient);
            container.Register<IInterface6, Class6>(Reuse.Transient);
            container.Register<IInterface7, Class7>(Reuse.Transient);
            container.Register<IInterface8, Class8>(Reuse.Transient);
            container.Register<IInterface9, Class9>(Reuse.Transient);
            container.Register<IInterface10, Class10>(Reuse.Transient);
            container.Register<IInterface11, Class11>(Reuse.Transient);
            container.Register<IInterface12, Class12>(Reuse.Transient);
            container.Register<IInterface13, Class13>(Reuse.Transient);
            container.Register<IInterface14, Class14>(Reuse.Transient);
            container.Register<IInterface15, Class15>(Reuse.Transient);
            container.Register<IInterface16, Class16>(Reuse.Transient);
            container.Register<IInterface17, Class17>(Reuse.Transient);
            container.Register<IInterface18, Class18>(Reuse.Transient);
            container.Register<IInterface19, Class19>(Reuse.Transient);
            container.Register<IInterface20, Class20>(Reuse.Transient);
            container.Register<IInterface21, Class21>(Reuse.Transient);
            container.Register<IInterface22, Class22>(Reuse.Transient);
            container.Register<IInterface23, Class23>(Reuse.Transient);
            container.Register<IInterface24, Class24>(Reuse.Transient);
            container.Register<IInterface25, Class25>(Reuse.Transient);
            container.Register<IInterface26, Class26>(Reuse.Transient);
            container.Register<IInterface27, Class27>(Reuse.Transient);
            container.Register<IInterface28, Class28>(Reuse.Transient);
            container.Register<IInterface29, Class29>(Reuse.Transient);
            container.Register<IInterface30, Class30>(Reuse.Transient);
            container.Register<IInterface31, Class31>(Reuse.Transient);
            container.Register<IInterface32, Class32>(Reuse.Transient);
            container.Register<IInterface33, Class33>(Reuse.Transient);
            container.Register<IInterface34, Class34>(Reuse.Transient);
            container.Register<IInterface35, Class35>(Reuse.Transient);
            container.Register<IInterface36, Class36>(Reuse.Transient);
            container.Register<IInterface37, Class37>(Reuse.Transient);
            container.Register<IInterface38, Class38>(Reuse.Transient);
            container.Register<IInterface39, Class39>(Reuse.Transient);
            container.Register<IInterface40, Class40>(Reuse.Transient);
            container.Register<IInterface41, Class41>(Reuse.Transient);
            container.Register<IInterface42, Class42>(Reuse.Transient);
            container.Register<IInterface43, Class43>(Reuse.Transient);
            container.Register<IInterface44, Class44>(Reuse.Transient);
            container.Register<IInterface45, Class45>(Reuse.Transient);
            container.Register<IInterface46, Class46>(Reuse.Transient);
            container.Register<IInterface47, Class47>(Reuse.Transient);
            container.Register<IInterface48, Class48>(Reuse.Transient);
            container.Register<IInterface49, Class49>(Reuse.Transient);
            ;
#endregion
        }

        public static void Resolve(Container container)
        {
#region resolution code
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
            var resolvedInstance10 = container.Resolve<IInterface10>();
            var resolvedInstance11 = container.Resolve<IInterface11>();
            var resolvedInstance12 = container.Resolve<IInterface12>();
            var resolvedInstance13 = container.Resolve<IInterface13>();
            var resolvedInstance14 = container.Resolve<IInterface14>();
            var resolvedInstance15 = container.Resolve<IInterface15>();
            var resolvedInstance16 = container.Resolve<IInterface16>();
            var resolvedInstance17 = container.Resolve<IInterface17>();
            var resolvedInstance18 = container.Resolve<IInterface18>();
            var resolvedInstance19 = container.Resolve<IInterface19>();
            var resolvedInstance20 = container.Resolve<IInterface20>();
            var resolvedInstance21 = container.Resolve<IInterface21>();
            var resolvedInstance22 = container.Resolve<IInterface22>();
            var resolvedInstance23 = container.Resolve<IInterface23>();
            var resolvedInstance24 = container.Resolve<IInterface24>();
            var resolvedInstance25 = container.Resolve<IInterface25>();
            var resolvedInstance26 = container.Resolve<IInterface26>();
            var resolvedInstance27 = container.Resolve<IInterface27>();
            var resolvedInstance28 = container.Resolve<IInterface28>();
            var resolvedInstance29 = container.Resolve<IInterface29>();
            var resolvedInstance30 = container.Resolve<IInterface30>();
            var resolvedInstance31 = container.Resolve<IInterface31>();
            var resolvedInstance32 = container.Resolve<IInterface32>();
            var resolvedInstance33 = container.Resolve<IInterface33>();
            var resolvedInstance34 = container.Resolve<IInterface34>();
            var resolvedInstance35 = container.Resolve<IInterface35>();
            var resolvedInstance36 = container.Resolve<IInterface36>();
            var resolvedInstance37 = container.Resolve<IInterface37>();
            var resolvedInstance38 = container.Resolve<IInterface38>();
            var resolvedInstance39 = container.Resolve<IInterface39>();
            var resolvedInstance40 = container.Resolve<IInterface40>();
            var resolvedInstance41 = container.Resolve<IInterface41>();
            var resolvedInstance42 = container.Resolve<IInterface42>();
            var resolvedInstance43 = container.Resolve<IInterface43>();
            var resolvedInstance44 = container.Resolve<IInterface44>();
            var resolvedInstance45 = container.Resolve<IInterface45>();
            var resolvedInstance46 = container.Resolve<IInterface46>();
            var resolvedInstance47 = container.Resolve<IInterface47>();
            var resolvedInstance48 = container.Resolve<IInterface48>();
            var resolvedInstance49 = container.Resolve<IInterface49>();
            ;
#endregion
        }
    }
}