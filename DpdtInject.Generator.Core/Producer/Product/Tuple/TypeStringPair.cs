﻿using Microsoft.CodeAnalysis;
using System;
using System.Runtime.CompilerServices;

namespace DpdtInject.Generator.Core.Producer.Product.Tuple
{
    public class TypeStringPair : IWritablePair
    {
        private readonly ITypeSymbol _item0;
        private readonly string _item1;

        public TypeStringPair(ITypeSymbol item0, string item1)
        {
            if (item0 is null)
            {
                throw new ArgumentNullException(nameof(item0));
            }

            if (item1 is null)
            {
                throw new ArgumentNullException(nameof(item1));
            }

            _item0 = item0;
            _item1 = item1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteItem0(IndentedTextWriter2 writer, ShortTypeNameGenerator sng)
        {
            writer.Write($"{sng.GetShortName(_item0)}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteItem1(IndentedTextWriter2 writer, ShortTypeNameGenerator sng)
        {
            writer.Write(_item1);
        }
    }

}
