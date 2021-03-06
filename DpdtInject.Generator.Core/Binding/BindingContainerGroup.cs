﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace DpdtInject.Generator.Core.Binding
{
    public class BindingContainerGroup
    {
        private readonly List<BindingContainerExtender> _bindingExtenders;

        public ITypeSymbol BindFrom
        {
            get;
        }

        public IReadOnlyList<BindingContainerExtender> BindingExtenders => _bindingExtenders;

        public BindingContainerGroup(
            ITypeSymbol bindFrom
            )
        {
            if (bindFrom is null)
            {
                throw new ArgumentNullException(nameof(bindFrom));
            }

            BindFrom = bindFrom;
            _bindingExtenders = new List<BindingContainerExtender>();
        }

        public void Add(BindingContainerExtender bindingExtender)
        {
            if (bindingExtender is null)
            {
                throw new ArgumentNullException(nameof(bindingExtender));
            }

            _bindingExtenders.Add(
                bindingExtender
                );
        }

    }
}
