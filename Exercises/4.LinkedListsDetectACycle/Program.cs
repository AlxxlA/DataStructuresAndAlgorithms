using System;

namespace _4.LinkedListsDetectACycle
{
    class Program
    {
        static void Main()
        {
            var first = new Node();
            var second = new Node();
            var third = new Node();

            first.Next = second;
            second.Next = third;

            Console.WriteLine(HasCycle(first));

            third.Next = second;

            Console.WriteLine(HasCycle(first));
        }

        private static bool HasCycle(Node node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.IsVisited)
            {
                return true;
            }

            node.IsVisited = true;

            var result = HasCycle(node.Next);

            node.IsVisited = false;

            return result;
        }
    }

    class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public bool IsVisited { get; set; }
    }
}
