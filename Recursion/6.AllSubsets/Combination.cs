using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.AllSubsets
{
    class Combination
    {
        static void Main()
        {
            int n = 3;//int.Parse(Console.ReadLine());
            int k = 2;//int.Parse(Console.ReadLine());
            var items = new List<string> { "test", "rock", "fun" };
            Combinations(items.Count, k, new int[k], items, new bool[n + 1]);
        }

        private static void Combinations<T>(int n, int k, int[] indexes, IList<T> items, bool[] used, int depth = 0, int start = 1)
        {
            if (depth == k)
            {
                Console.WriteLine(string.Join(" ", indexes.Select(i => items[i - 1])));
                return;
            }
            for (int i = start; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    indexes[depth] = i;
                    Combinations(n, k, indexes, items, used, depth + 1, i);
                    used[i] = false;
                }
            }
        }
    }
}
