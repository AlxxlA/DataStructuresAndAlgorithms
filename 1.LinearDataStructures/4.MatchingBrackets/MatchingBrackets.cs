using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main()
        {
            string expression = Console.ReadLine();

            var stack = new Stack<char>();
            var indexes = new Stack<int>();
            var subExpresions = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                var ch = expression[i];
                if (ch == '(')
                {
                    stack.Push(ch);
                    indexes.Push(i);
                }
                else if (ch == ')')
                {
                    if (stack.Count == 0)
                    {
                        throw new ArgumentException("Invalid brackets.");
                    }
                    stack.Pop();
                    var startIndex = indexes.Pop();
                    subExpresions.Add(expression.Substring(startIndex, i - startIndex + 1));
                }
            }

            if (stack.Count != 0)
            {
                throw new ArgumentException("Invalid brackets.");
            }

            //Console.WriteLine(string.Join(" | ", subExpresions));
            foreach (var expresion in subExpresions)
            {
                Console.WriteLine(expresion);
            }
        }
    }
}