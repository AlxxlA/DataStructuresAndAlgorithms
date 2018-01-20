using System;
using System.Numerics;

namespace _11.BracketMaster
{
    class Program
    {
        private static BigInteger[] memo;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 1)
            {
                Console.WriteLine(0);
                return;
            }
            if (n == 0)
            {
                Console.WriteLine(1);
                return;
            }

            memo = new BigInteger[n / 2 + 1];
            var catalan = Catalan(n / 2);

            var big = BigInteger.Pow(4, n / 2);
            BigInteger result = BigInteger.Multiply(big, catalan);

            Console.WriteLine(result);
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
