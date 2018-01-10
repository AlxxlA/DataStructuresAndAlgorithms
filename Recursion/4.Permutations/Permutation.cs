using System;

namespace _4.Permutations
{
    class Permutation
    {
        static void Main()
        {
            var arr = new[] { 1, 2, 3 };
            Permutations(arr.Length, arr);
        }

        private static void Permutations<T>(int n, T[] arr)
        {
            if (n == 1)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < n - 1; i++)
            {
                Permutations(n - 1, arr);
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
            Permutations(n - 1, arr);
        }
    }
}
