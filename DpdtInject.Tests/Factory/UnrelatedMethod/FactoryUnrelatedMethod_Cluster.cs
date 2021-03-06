﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Factory.UnrelatedMethod
{
    public partial class FactoryUnrelatedMethod_Cluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IAFactory>()
                .ToIsolatedFactory<AFactory>()
                .WithPayload<A>()
                .WithSingletonScope()
                ;
        }

        public class FactoryUnrelatedMethod_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<FactoryUnrelatedMethod_Cluster>(
                    null
                    );

                var af = cluster.Get<IAFactory>();
                Assert.IsNotNull(af);

                var a0 = af.Create();
                Assert.IsNotNull(a0);

                var a1 = af.Create();
                Assert.IsNotNull(a1);

                Assert.AreNotSame(a0, a1);
            }
        }
    }


    public interface IA
    {
    }

    public class A : IA
    {
    }

    public interface IAFactory
    {
        string GetSomeString();

        IA Create();
    }

    public partial class AFactory : IFakeFactory<IAFactory>
    {
        public string GetSomeString() => "1";
    }
}
