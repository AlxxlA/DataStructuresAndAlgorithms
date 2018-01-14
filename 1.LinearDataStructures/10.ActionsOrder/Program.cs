using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ActionsOrder
{
    class Program
    {
        static void Main()
        {
            int n;
            int m;
            ReadTwoNumbers(out n, out m);

            var list = new LinkedList<int>();
            var nodes = new Dictionary<int, LinkedListNode<int>>();


            for (int i = 0; i < n; i++)
            {
                var node = new LinkedListNode<int>(i);
                list.AddLast(node);
                nodes.Add(i, node);
            }

            for (int i = 0; i < m; i++)
            {
                int a;
                int b;
                ReadTwoNumbers(out a, out b);

                var nodeA = nodes[a];
                var nodeB = nodes[b];

                if (!IsBefore(nodeA, nodeB))
                {
                    list.Remove(nodeB);
                    var next = nodeA;

                    while (next != null)
                    {
                        if (next.Next?.Value > nodeB.Value)
                        {
                            break;
                        }
                        next = next.Next;
                    }
                    if (next != null)
                    {
                        list.AddAfter(next, nodeB);
                    }
                    else
                    {
                        list.AddLast(nodeB);
                    }
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static bool IsBefore(LinkedListNode<int> nodeA, LinkedListNode<int> nodeB)
        {
            var current = nodeA;

            while (current != null)
            {
                if (current == nodeB)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        private static void ReadTwoNumbers(out int a, out int b)
        {
            string line = Console.ReadLine();
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            a = numbers[0];
            b = numbers[1];
        }
    }
}
