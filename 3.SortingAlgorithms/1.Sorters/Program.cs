using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sorters
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int numberOfElements = 10000000;
            var list = Enumerable.Range(1, numberOfElements).Select(x => random.Next(0, 1000000000)).ToList();
            //   Console.WriteLine(string.Join(", ", list));

            //  Console.WriteLine(IsSorted(list));

            var stopWatch = new Stopwatch();

            var quickSorter = new Quicksorter<int>();
            stopWatch.Start();
            quickSorter.Sort(list);
            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            //list = Enumerable.Range(1, numberOfElements).Select(x => random.Next(0, 1000000000)).ToList();
            //stopWatch.Reset();
            //list.Sort();
            //Console.WriteLine(stopWatch.ElapsedMilliseconds);

            Console.WriteLine(IsSorted(list));

            //Console.WriteLine(string.Join(", ", list));


        }

        static bool IsSorted<T>(IList<T> collection) where T : IComparable
        {
            var prevElement = collection[0];
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(prevElement) < 0)
                {
                    return false;
                }

                prevElement = collection[i];
            }

            return true;
        }
    }
}
