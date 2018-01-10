using System;

namespace CombinationsWithDuplicates
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Combinations(n, k, new int[k]);
        }

        private static void Combinations(int n, int k, int[] arr, int depth = 0, int start = 1)
        {
            if (depth == k)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = start; i <= n; i++)
            {
                arr[depth] = i;
                Combinations(n, k, arr, depth + 1, i);
            }
        }
    }
}
