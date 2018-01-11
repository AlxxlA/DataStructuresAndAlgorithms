using System;
using System.Collections.Generic;

namespace _1.Sorters
{
    public interface ISorter<T> where T : IComparable
    {
        void Sort(IList<T> collection);
    }
}
