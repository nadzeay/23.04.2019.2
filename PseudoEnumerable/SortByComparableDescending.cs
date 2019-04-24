using System;
using System.Collections.Generic;

namespace PseudoEnumerable
{
    internal class SortByComparableDescending<TSource, TKey> : IComparer<TSource>
    {
        Func<TSource, TKey> key;
        IComparer<TKey> comparer;

        public SortByComparableDescending(Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            this.key = key;
            this.comparer = comparer;
        }

        public int Compare(TSource x, TSource y) => comparer.Compare(key(y), key(x));
    }
}
