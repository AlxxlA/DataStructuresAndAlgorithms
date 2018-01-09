using System;

namespace NestedLoopsRecursion
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Loop(n, new int[n]);
        }

        private static void Loop(int n, int[] arr, int k = 0)
        {
            if (k == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                arr[k] = i;
                Loop(n, arr, k + 1);
            }
        }
    }
}
