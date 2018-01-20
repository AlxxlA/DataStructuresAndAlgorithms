using System;
using System.Numerics;

namespace _12.CatalanNumbers
{
    class Program
    {
        private static BigInteger[] memo;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            memo = new BigInteger[n + 1];

            Console.WriteLine(Catalan(n));
        }

        private static BigInteger Catalan(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (memo[n] != 0)
            {
                return memo[n];
            }

            var result = new BigInteger(0);

            for (int i = 0; i < n; i++)
            {
                result += Catalan(i) * Catalan(n - i - 1);
            }

            memo[n] = result;

            return result;
        }
    }
}
