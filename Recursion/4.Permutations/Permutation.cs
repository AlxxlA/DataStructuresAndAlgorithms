using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Permutations
{
    class Permutation
    {
        private static List<string> results = new List<string>();
        private static int[] arr;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            arr = Enumerable.Range(1, n).ToArray();
            Permutations(n);

            results.Sort();

            Console.WriteLine(string.Join("\n", results));
        }

        private static void Permutations(int n)
        {
            if (n == 1)
            {
                results.Add(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < n - 1; i++)
            {
                Permutations(n - 1);
                if (n % 2 == 0)
                {
                    var temp = arr[n - 1];
                    arr[n - 1] = arr[i];
                    arr[i] = temp;
                }
                else
                {
                    var temp = arr[n - 1];
                    arr[n - 1] = arr[0];
                    arr[0] = temp;
                }
            }
            Permutations(n - 1);
        }
    }
}
