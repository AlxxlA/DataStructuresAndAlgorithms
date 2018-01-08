using System;
using System.Collections.Generic;

namespace _1.PrimeNumbers
{
    class PrimeNumbersInRange
    {
        static void Main()
        {
            uint start = uint.Parse(Console.ReadLine());
            start = Math.Max(2, start); // because 1 is not a prime number
            uint end = uint.Parse(Console.ReadLine());

            var primeNumbers = new List<uint>();

            for (var number = start; number <= end; number++)
            {
                bool isPrime = true;

                for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
                {
                    if (number % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeNumbers.Add(number);
                }
            }

            foreach (var primeNumber in primeNumbers)
            {
                Console.WriteLine(primeNumber);
            }
        }
    }
}