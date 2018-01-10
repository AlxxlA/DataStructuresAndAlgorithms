﻿using System;
using System.Linq;

namespace Variations
{
    class Variation
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var arr = new[] { "hi", "a", "b" };
            Variation(n, k, new int[k], arr);
        }

        private static void Variations<T>(int n, int k, int[] indexes, T[] arr, int depth = 0)
        {
            if (depth == k)
            {
                Console.WriteLine(string.Join(" ", indexes.Select(i => arr[i])));
                return;
            }
            for (int i = 0; i < n; i++)
            {
                indexes[depth] = i;
                Variation(n, k, indexes, arr, depth + 1);
            }
        }
    }
}