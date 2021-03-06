﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src.Bind.Settings.CrossCluster;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Cluster.Generic.DifferentConditional3
{
    public partial class ClusterGenericDifferentConditional3_RootCluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithTransientScope()
                .When(rt => rt.ParentTarget.TargetType == typeof(B))
                ;

            Bind<IB>()
                .To<B>()
                .WithTransientScope()
                .When(rt => rt.ParentTarget.TargetType == typeof(C))
                ;
        }
    }

    public partial class ClusterGenericDifferentConditional3_ChildCluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IC>()
                .To<C>()
                .WithTransientScope()
                .Setup<AllowedCrossCluster>()
                ;
        }
    }


    public class ClusterGenericDifferentConditional3_ClusterTester
    {
        public void PerformClusterTesting()
        {
            var rootCluster = new FakeCluster<ClusterGenericDifferentConditional3_RootCluster>(
                null
                );
            var childCluster = new FakeCluster<ClusterGenericDifferentConditional3_ChildCluster>(
                rootCluster
                );

            var c = childCluster.Get<IC>();
            Assert.IsNotNull(c);
            Assert.IsNotNull(c.B);
            Assert.IsNotNull(c.B.A);
        }
    }

    public interface IA
    {
    }

    public class A : IA
    {
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
        public IA A
        {
            get;
        }

        public B(
            IA a
            )
        {
            A = a;
        }
    }

    public interface IC
    {
        IB B
        {
            get;
        }
    }

    public class C : IC
    {
        public IB B
        {
            get;
        }

        public C(
            IB b
            )
        {
            B = b;
        }
    }
}
