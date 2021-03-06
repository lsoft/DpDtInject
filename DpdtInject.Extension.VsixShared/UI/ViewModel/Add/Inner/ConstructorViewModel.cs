﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DpdtInject.Extension.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell;

namespace DpdtInject.Extension.UI.ViewModel.Add.Inner
{
    public class ConstructorViewModel : BaseViewModel
    {
        private bool _isChecked;
        private readonly Action<bool> _isCheckedChanged;

        public INamedTypeSymbol TargetType
        {
            get;
        }

        public IMethodSymbol Constructor
        {
            get;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    _isCheckedChanged(_isChecked);
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        public string VisualRepresentation
        {
            get;
        }

        public Brush ForegroundColor
        {
            get;
        }



        /// <inheritdoc />
        public ConstructorViewModel(
            INamedTypeSymbol targetType,
            IMethodSymbol constructor,
            Action<bool> isCheckedChanged
            )
        {
            if (constructor is null)
            {
                throw new ArgumentNullException(nameof(constructor));
            }

            TargetType = targetType;
            Constructor = constructor;
            _isCheckedChanged = isCheckedChanged;
            var arguments = string.Join(
                ", ",
                constructor.Parameters.Select(p => $"{p.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} {p.Name}")
                );

            if (constructor.DeclaredAccessibility == Accessibility.Public)
            {
                VisualRepresentation = $"{targetType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}( {arguments} )";
                ForegroundColor = (Brush)Application.Current.FindResource(VsBrushes.WindowTextKey);
            }
            else
            {
                VisualRepresentation = $"{targetType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}( {arguments} )    ({constructor.DeclaredAccessibility})";
                ForegroundColor = Brushes.Gray;
            }
        }
    }
}
