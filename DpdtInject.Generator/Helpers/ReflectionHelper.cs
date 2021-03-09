﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DpdtInject.Generator.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<MethodInfo> GetAllNonStaticMethodsHierarchy(this Type type)
        {
            if (type is null)
            {
                yield break;
            }

            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                yield return method;
            }
            if (type.IsInterface)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    foreach (var method in GetAllNonStaticMethodsHierarchy(iface))
                    {
                        yield return method;
                    }
                }
            }
        }
    }
}
