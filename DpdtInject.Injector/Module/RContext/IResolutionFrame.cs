﻿using System;

namespace DpdtInject.Injector.Module.RContext
{
    public interface IResolutionFrame
    {
        Type RequestedType
        {
            get;
        }

        Type TargetType
        {
            get;
        }

        //string Name
        //{
        //    get;
        //}

        string? ConstructorArgumentName
        {
            get;
        }
    }
}