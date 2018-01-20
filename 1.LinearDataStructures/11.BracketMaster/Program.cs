﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _11.BracketMaster
{
    class Program
    {
        private static BigInteger[] memo;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 1 || n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            memo = new BigInteger[n];
            var catalans = AllCatalans(n);

            var big = BigInteger.Pow(4, n / 2);
            BigInteger result = BigInteger.Multiply(big, catalans[n / 2]);

            Console.WriteLine(result);
        }

        private static BigInteger[] AllCatalans(int n)
        {
            var result = new BigInteger[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = Catalan(i);
            }

            return result;
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