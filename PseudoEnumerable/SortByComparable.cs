using System;
using System.Collections.Generic;

namespace PseudoEnumerable
{
    internal class SortByComparable<TSource, TKey> : IComparer<TSource>
    {
        Func<TSource, TKey> key;
        IComparer<TKey> comparer;

        public SortByComparable(Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            this.key = key;
            this.comparer = comparer;
        }

        public int Compare(TSource x, TSource y) => comparer.Compare(key(x), key(y));
    }
}
