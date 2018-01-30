using System;
using System.Linq;

namespace _1.ArraysLeftRotation
{
    class Solution
    {

        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens[0]);
            int k = Convert.ToInt32(tokens[1]);

            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rotatedArr = RotateArray(arr, k);

            Console.WriteLine(string.Join(" ", rotatedArr));
        }

        private static int[] RotateArray(int[] arr, int rotations)
        {
            int n = arr.Length;
            rotations %= n;

            var resultArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newIndex = i - rotations;

                if (newIndex < 0)
                {
                    newIndex += n;
                }

                resultArr[newIndex] = arr[i];
            }

            return resultArr;
        }
    }
}
