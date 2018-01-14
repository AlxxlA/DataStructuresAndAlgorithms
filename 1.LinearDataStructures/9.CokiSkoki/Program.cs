using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.CokiSkoki
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var buildings = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var currentMax = buildings[n - 1];

            var jumps = new int[n];

            var stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                int current = buildings[i];

                if (stack.Count == 0)
                {
                    currentMax = current;
                    jumps[i] = 0;
                }
                else if (current >= currentMax)
                {
                    stack = new Stack<int>();
                    currentMax = current;
                    jumps[i] = 0;
                }
                else
                {
                    int index = i + 1;
                    foreach (var item in stack)
                    {
                        if (current < item)
                        {
                            jumps[i] = jumps[index] + 1;
                            break;
                        }
                        index++;
                    }
                }
                stack.Push(buildings[i]);
            }

            Console.WriteLine(jumps.Max());
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}
