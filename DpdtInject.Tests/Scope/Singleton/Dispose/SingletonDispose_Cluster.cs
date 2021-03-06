﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Scope.Singleton.Dispose
{
    public partial class SingletonDispose_Cluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithSingletonScope()
                ;
        }


        public class SingletonDispose_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<SingletonDispose_Cluster>(
                    null
                    );

                var a0 = cluster.Get<IA>();
                Assert.IsNotNull(a0);

                Assert.AreEqual(0, A.DisposeCount);

                cluster.Dispose();

                Assert.AreEqual(1, A.DisposeCount);
            }
        }
    }


    public interface IA
    {
    }

    public class A : IA, IDisposable
    {
        public static int DisposeCount = 0;

        public void Dispose()
        {
            DisposeCount++;
        }
    }
}
