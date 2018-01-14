using System;
using System.Collections.Generic;

namespace _1.Sorters
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivotIndex = start;

            var pivot = collection[pivotIndex];
            var storeIndex = pivotIndex + 1;

            for (int i = pivotIndex + 1; i < end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, storeIndex, i);
                    storeIndex++;
                }
            }

            Swap(collection, pivotIndex, storeIndex - 1);

            this.QuickSort(collection, start, storeIndex - 1);
            this.QuickSort(collection, storeIndex, end);
        }

        private static void Swap(IList<T> collection, int i, int j)
        {
            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
    }
}
