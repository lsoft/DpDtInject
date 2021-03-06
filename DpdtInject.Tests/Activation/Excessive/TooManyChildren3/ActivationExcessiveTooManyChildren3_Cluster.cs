﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using DpdtInject.Injector.Src.Excp;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Activation.Excessive.TooManyChildren3
{
    public partial class ActivationExcessiveTooManyChildren3_Cluster : DefaultCluster
    {
        public const string Message = "some message";

        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A1>()
                .WithSingletonScope()
                .When(rc => false)
                ;

            Bind<IA>()
                .To<A2>()
                .WithSingletonScope()
                .When(rc => false)
                ;

            Bind<IB>()
                .To<B>()
                .WithSingletonScope()
                ;
        }


        public class ActivationExcessiveTooManyChildren3_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<ActivationExcessiveTooManyChildren3_Cluster>(
                    null
                    );

                try
                {
                    var b = cluster.Get<IB>();

                    Assert.Fail("this line should never be executed");
                }
                catch (DpdtException excp)
                    when (excp.Type == DpdtExceptionTypeEnum.NoBindingAvailable && excp.AdditionalArgument == typeof(IA).FullName)
                {
                    //it's OK, this test is gree
                }

                Assert.AreEqual(0, B.ActivationCount, "B.ActivationCount");
                Assert.AreEqual(0, A1.ActivationCount, "A1.ActivationCount");
                Assert.AreEqual(0, A2.ActivationCount, "A2.ActivationCount");
            }
        }
    }


    public interface IA
    {
    }

    public class A2 : IA
    {
        public static long ActivationCount = 0L;

        public A2()
        {
            Interlocked.Increment(ref ActivationCount);
        }
    }

    public class A1 : IA
    {
        public static long ActivationCount = 0L;

        public A1()
        {
            Interlocked.Increment(ref ActivationCount);
        }
    }

    public interface IB
    {
        IA A
        {
            get;
        }
    }

    public class B : IB
    {
        public static long ActivationCount = 0L;

        public IA A
        {
            get;
        }

        public B(
            IA a
            )
        {
            Interlocked.Increment(ref ActivationCount);

            A = a;
        }
    }
}
