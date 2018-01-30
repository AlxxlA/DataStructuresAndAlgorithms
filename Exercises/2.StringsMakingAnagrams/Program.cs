using System;
using System.Collections.Generic;

namespace _2.StringsMakingAnagrams
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            var allSymbols = new HashSet<char>();
            var firstStringSymbols = new Dictionary<char, int>();
            var secondStringSymbols = new Dictionary<char, int>();

            foreach (var ch in a)
            {
                if (!firstStringSymbols.ContainsKey(ch))
                {
                    firstStringSymbols.Add(ch, 0);
                }

                firstStringSymbols[ch]++;
                allSymbols.Add(ch);
            }

            foreach (var ch in b)
            {
                if (!secondStringSymbols.ContainsKey(ch))
                {
                    secondStringSymbols.Add(ch, 0);
                }

                secondStringSymbols[ch]++;
                allSymbols.Add(ch);
            }

            var symbolsForDelition = 0;

            foreach (var symbol in allSymbols)
            {
                if (firstStringSymbols.ContainsKey(symbol) && secondStringSymbols.ContainsKey(symbol))
                {
                    int min = Math.Min(firstStringSymbols[symbol], secondStringSymbols[symbol]);
                    int max = Math.Max(firstStringSymbols[symbol], secondStringSymbols[symbol]);

                    symbolsForDelition += max - min;
                }
                else if (firstStringSymbols.ContainsKey(symbol))
                {
                    symbolsForDelition += firstStringSymbols[symbol];
                }
                else if (secondStringSymbols.ContainsKey(symbol))
                {
                    symbolsForDelition += secondStringSymbols[symbol];
                }
            }

            Console.WriteLine(symbolsForDelition);
        }
    }
}
