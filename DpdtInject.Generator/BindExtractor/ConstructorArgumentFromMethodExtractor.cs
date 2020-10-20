﻿using DpdtInject.Generator.Binding;
using DpdtInject.Injector.Helper;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace DpdtInject.Generator.BindExtractor
{
    public class ConstructorArgumentFromMethodExtractor
    {
        public List<DetectedConstructorArgument> GetConstructorArguments(
            IMethodSymbol methodSymbol
            )
        {
            if (methodSymbol is null)
            {
                throw new ArgumentNullException(nameof(methodSymbol));
            }

            return
                methodSymbol.Parameters.ConvertAll(
                    p => new DetectedConstructorArgument(
                        p.Name, 
                        p.Type, 
                        p.HasExplicitDefaultValue,
                        () => p.ExplicitDefaultValue
                        )
                    );
        }
    }
}