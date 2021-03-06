﻿using System;
using DpdtInject.Injector.Src.Bind;

namespace DpdtInject.Injector.Src
{
    public abstract class DefaultCluster
    {
        public const string BindMethodName = nameof(Bind);
        public const string BindAllInterfacesMethodName = nameof(BindAllInterfaces);
        public const string ScanInAssembliesWithMethodName = nameof(ScanInAssembliesWith);

        protected IConventionalBinding ScanInAssembliesWith<T1>(
            )
        {
            throw new NotImplementedException();
        }

        protected IConventionalBinding ScanInAssembliesWith<T1, T2>(
            )
        {
            throw new NotImplementedException();
        }

        protected IConventionalBinding ScanInAssembliesWith<T1, T2, T3>(
            )
        {
            throw new NotImplementedException();
        }




        protected IToOrConstantBinding BindAllInterfaces(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T1, T2, T3, T4, T5, T6>(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T1, T2, T3, T4, T5>(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T1, T2, T3, T4>(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T1, T2, T3>(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T1, T2>(
            )
        {
            throw new NotImplementedException();
        }

        protected IToOrConstantBinding Bind<T>(
            )
        {
            throw new NotImplementedException();
        }
    }
}
