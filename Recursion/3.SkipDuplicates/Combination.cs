using System;

namespace _3.SkipDuplicates
{
    class Combination
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Combinations(n, k, new int[k], new bool[n + 1]);
        }

        private static void Combinations(int n, int k, int[] arr, bool[] used, int depth = 0, int start = 1)
        {
            if (depth == k)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = start; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[depth] = i;
                    Combinations(n, k, arr, used, depth + 1, i);
                    used[i] = false;
                }
            }
        }
    }
}
