using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 1, 6, 4, 2, 5 };

            Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        static void Sort(int[] arr)
        {
            Quicksort(arr, 0, arr.Length - 1);
        }

        static void Quicksort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(arr, lo, hi);
                Quicksort(arr, lo, p);
                Quicksort(arr, p + 1, hi);
            }
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[lo];

            int i = lo - 1;
            int j = hi + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (i < hi && arr[i] < pivot);

                do
                {
                    j--;
                } while (j >= lo && arr[j] > pivot);

                if (i >= j)
                {
                    break;
                }
            }

            Swap(arr, i, j);
            return j;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
