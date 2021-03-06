﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DpdtInject.Injector.Src.Bind.Settings.Wrapper;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Wrapper.Func.NonGeneric.SingleInterfaceSingleObject
{
    public partial class WrapperFuncNonGenericSingleInterfaceSingleObject_Cluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithTransientScope()
                .Setup<ProduceWrappers>()
                ;
        }

        public class WrapperFuncNonGenericSingleInterfaceSingleObject_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<WrapperFuncNonGenericSingleInterfaceSingleObject_Cluster>(
                    null
                    );

                var a0 = (IA) cluster.Get(typeof(IA));
                Assert.IsNotNull(a0);

                var af1 = (Func<IA>) cluster.Get(typeof(Func<IA>));
                Assert.IsNotNull(af1);
                var a1 = af1();

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
