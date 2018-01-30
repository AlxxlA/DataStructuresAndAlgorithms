using System;
using System.Collections.Generic;

namespace _5.StacksBalancedBrackets
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string expresion = Console.ReadLine();
                if (IsValidBrackets(expresion))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static bool IsValidBrackets(string expresion)
        {
            var matchingBrackets = new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' }
            };

            var stack = new Stack<char>();

            foreach (var bracket in expresion)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    stack.Push(bracket);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var prev = stack.Pop();

                    if (matchingBrackets[prev] != bracket)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
