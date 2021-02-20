﻿using DpdtInject.Injector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DpdtInject.Tests.Scope.Transient.Generic.SingleInterfaceSingleObject
{
    public partial class ScopeTransientGenericSingleInterfaceSingleObject_Cluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithTransientScope()
                ;
        }

        public class ScopeTransientGenericSingleInterfaceSingleObject_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<ScopeTransientGenericSingleInterfaceSingleObject_Cluster>(
                    null
                    );

                var a0 = cluster.Get<IA>();
                Assert.IsNotNull(a0);

                var a1 = cluster.Get<IA>();
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
}
