﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src.Bind.Settings.Circular;
using DpdtInject.Injector.Src.Bind;
using DpdtInject.Injector.Src.RContext;
using DpdtInject.Injector.Src;

namespace DpdtInject.Tests.Proxy.Simple0
{
    public partial class ProxySimple0_Cluster : DefaultCluster
    {
        [DpdtBindingMethod]
        public void BindMethod()
        {
            Bind<SessionSaver>()
                .To<SessionSaver>()
                .WithSingletonScope()
                ;

            Bind<IMethodContainer>()
                .To<MethodContainer>()
                .WithSingletonScope()
                .When(rt => rt.WhenInjectedExactlyInto<MethodContainerProxy>())
                ;

            Bind<IMethodContainer>()
                .ToProxy<MethodContainerProxy>()
                .WithProxySettings<TelemetryAttribute, SessionSaver>()
                .WithSingletonScope()
                .Setup<SuppressCircularCheck>()
                .When(rt => rt.WhenInjectedExactlyNotInto<MethodContainerProxy>())
                ;

        }

        public class ProxySimple0_ClusterTester
        {
            public void PerformClusterTesting()
            {
                var cluster = new FakeCluster<ProxySimple0_Cluster>(
                    null
                    );

                var calculator = cluster.Get<IMethodContainer>();
                Assert.IsNotNull(calculator);

                const int InitialValue = 1;

                var initialValueCopy = InitialValue;
                var wopIncremented = calculator.DoIncrementWithoutProxy(ref initialValueCopy);
                Assert.AreEqual(InitialValue + 1, wopIncremented);
                Assert.IsFalse(SessionSaver.ProxyWasInDeal);

                var someConstant = calculator.GetSomeConstant();
                Assert.AreEqual(MethodContainer.SomeConstant, someConstant);
                Assert.IsFalse(SessionSaver.ProxyWasInDeal);

                calculator.DoNothing();
                Assert.IsTrue(MethodContainer.DoNothingExecuted);

                var one = calculator.GetOne();
                Assert.AreEqual(1, one);

                var wpIncremented = calculator.DoIncrement(InitialValue);
                Assert.AreEqual(InitialValue + 1, wpIncremented);

                Assert.IsTrue(SessionSaver.ProxyWasInDeal);
                Assert.AreEqual(typeof(MethodContainer).FullName, SessionSaver.FullClassName);
                Assert.AreEqual(nameof(MethodContainer.DoIncrement), SessionSaver.MemberName);
                Assert.IsTrue(SessionSaver.TakenInSeconds > 0.0);
                Assert.IsNull(SessionSaver.Exception);
                Assert.IsNotNull(SessionSaver.Arguments);
                Assert.AreEqual(2, SessionSaver.Arguments.Length);
                Assert.AreEqual(MethodContainer.ArgumentName, SessionSaver.Arguments[0] as string);
                Assert.AreEqual(InitialValue, (int)SessionSaver.Arguments[1]);
            }
        }
    }


    [AttributeUsage(AttributeTargets.Method)]
    public class TelemetryAttribute : Attribute
    {
    }


    /// <summary>
    /// In real applications this class MUST be THREAD SAFE!
    /// </summary>
    public class SessionSaver : BaseSessionSaver
    {
        public static Guid SessionGuid
        {
            get;
            private set;
        }

        public static bool ProxyWasInDeal
        {
            get;
            private set;
        }

        public static string FullClassName
        {
            get;
            private set;
        }

        public static string MemberName
        {
            get;
            private set;
        }

        public static double TakenInSeconds
        {
            get;
            private set;
        }

        public static Exception? Exception
        {
            get;
            private set;
        }

        public static object[]? Arguments
        {
            get;
            private set;
        }

        /// <summary>
        /// Fixes the current session to a permanent storage.
        /// DO NOT RAISE AN EXCEPTION HERE!
        /// </summary>
        public override Guid StartSessionSafely(
            in string fullClassName,
            in string memberName,
            in object[]? arguments
            )
        {
            ProxyWasInDeal = true;
            FullClassName = fullClassName;
            MemberName = memberName;
            Arguments = arguments;

            SessionGuid = Guid.NewGuid();
            return SessionGuid;
        }


        public override void FixSessionSafely(
            in Guid sessionGuid,
            in double takenInSeconds,
            Exception? exception
            )
        {
            if (SessionGuid != sessionGuid)
            {
                throw new InvalidOperationException("Session guids are different!");
            }

            TakenInSeconds = takenInSeconds;
            Exception = exception;
        }

    }


    public interface IMethodContainer
    {
        [Telemetry]
        void DoNothing(
            );

        [Telemetry]
        int GetOne(
            );

        [Telemetry]
        int DoIncrement(
            in int number
            );

        int DoIncrementWithoutProxy(
            ref int wopNumber
            );

        ref readonly int GetSomeConstant(
            );
    }

    public class MethodContainer : IMethodContainer
    {
        public static readonly int SomeConstant = 123;

        public static string ArgumentName = string.Empty;

        public static bool DoNothingExecuted = false;

        /// <inheritdoc />
        public void DoNothing()
        {
            DoNothingExecuted = true;
        }

        /// <inheritdoc />
        public int GetOne()
        {
            return 1;
        }

        /// <inheritdoc />
        public int DoIncrement(
            in int number
            )
        {
            //just for help in case of argument rename
            ArgumentName = nameof(number);
            
            Thread.Sleep(100);

            return number + 1;
        }

        /// <inheritdoc />
        public int DoIncrementWithoutProxy(
            ref int wopNumber
            )
        {
            return wopNumber + 1;
        }

        /// <inheritdoc />
        public ref readonly int GetSomeConstant()
        {
            return ref SomeConstant;
        }
    }

    public partial class MethodContainerProxy : IFakeProxy<IMethodContainer>
    {
    }

}
