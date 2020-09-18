﻿using DpdtInject.Injector;
using DpdtInject.Injector.Module;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DpdtInject.Injector.Module.Bind;
using DpdtInject.Injector.Excp;
using System.Threading;

namespace DpdtInject.Tests.Activation.Excessive.TooManyChildren2
{
    public partial class ActivationExcessiveTooManyChildren2Module : DpdtModule
    {
        public const string Message = "some message";

        public override void Load()
        {
            Bind<IA>()
                .To<A1>()
                .WithSingletonScope()
                .When(rc => true)
                ;

            Bind<IA>()
                .To<A2>()
                .WithSingletonScope()
                .When(rc => true)
                ;

            Bind<IB>()
                .To<B>()
                .WithSingletonScope()
                ;
        }

        public class ActivationExcessiveTooManyChildren2Tester
        {
            public void PerformModuleTesting()
            {
                var module = new FakeModule<ActivationExcessiveTooManyChildren2Module>();

                try
                {
                    var b = module.Get<IB>();

                    Assert.Fail("this line should never be executed");
                }
                catch (DpdtException excp)
                when (excp.Type == DpdtExceptionTypeEnum.DuplicateBinding && excp.AdditionalArgument == typeof(IA).FullName)
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
        IA A { get; }
    }

    public class B : IB
    {
        public static long ActivationCount = 0L;

        public IA A { get; }

        public B(IA a)
        {
            Interlocked.Increment(ref ActivationCount);

            A = a;
        }
    }


}