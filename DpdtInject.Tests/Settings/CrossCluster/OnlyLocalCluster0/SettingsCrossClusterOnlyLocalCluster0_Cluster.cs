﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src.Bind.Settings.CrossCluster;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Settings.CrossCluster.OnlyLocalCluster0
{
    public partial class SettingsCrossClusterOnlyLocalCluster0_RootCluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IA>()
                .To<A>()
                .WithTransientScope()
                ;
        }
    }

    public partial class SettingsCrossClusterOnlyLocalCluster0_ChildCluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<IB>()
                .To<B>()
                .WithTransientScope()
                .Setup<OnlyLocalCluster>()
                ;
        }
    }

    public class SettingsCrossClusterOnlyLocalCluster0_ClusterTester
    {
        public void PerformClusterTesting()
        {
            //no need to have code here, there was compilation error
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
}
