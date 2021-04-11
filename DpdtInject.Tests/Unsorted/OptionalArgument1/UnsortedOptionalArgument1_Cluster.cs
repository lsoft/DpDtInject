﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Unsorted.OptionalArgument1
{
    public partial class UnsortedOptionalArgument1_Cluster : DefaultCluster
    {
        public const string DefaultMessage = "default message";

        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithSingletonScope()
                ;
        }

        public class UnsortedOptionalArgument1_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<UnsortedOptionalArgument1_Cluster>(
                    null
                    );

                var a = cluster.Get<IA>();
                Assert.IsNotNull(a);
                Assert.AreEqual(DefaultMessage, a.Message);
            }
        }
    }


    public interface IA
    {
        string Message
        {
            get;
        }
    }

    public class A : IA
    {
        public string Message
        {
            get;
        }

        public A(
            string message = UnsortedOptionalArgument1_Cluster.DefaultMessage
            )
        {
            Message = message;
        }
    }
}
