﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DpdtInject.Injector.Excp
{
    public enum DpdtExceptionTypeEnum
    {
        NotSpecified,
        GeneralError,
        InternalError,
        ConstructorArgumentMiss,
        InvalidTestConfiguration,
        DuplicateBinding,
        NoBindingAvailable,
        IncorrectBinding,
        CircularDependency,
        UnknownName,
        ConstantCantHaveConstructorArguments,
        UnknownScope,
        IncorrectScope,
        SingletonTakesTransient
    }

    public class DpdtException : Exception
    {
        public DpdtExceptionTypeEnum Type
        {
            get;
        }
        public string AdditionalArgument
        {
            get;
        }

        public DpdtException(DpdtExceptionTypeEnum type, string message, string additionalArgument = "")
            : base(message)
        {
            Type = type;
            AdditionalArgument = additionalArgument;
        }

        public DpdtException(DpdtExceptionTypeEnum type, string message, Exception innerException, string additionalArgument = "")
            : base(message, innerException)
        {
            Type = type;
            AdditionalArgument = additionalArgument;
        }


    }
}
