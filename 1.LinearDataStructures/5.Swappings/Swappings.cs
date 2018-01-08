using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Swappings
{
    class Swappings
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var dict = new Dictionary<int, Node>();

            Node head = null;
            Node tail = null;
            Node prev = null;

            for (int i = 1; i <= n; i++)
            {

                var node = new Node(i, prev);
                prev = node;
                if (head == null)
                {
                    head = node;
                }

                tail = node;
                dict.Add(i, node);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Swap(dict[arr[i]], ref head, ref tail);
            }

            var current = head;

            var result = new List<int>(n);

            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            Console.WriteLine(string.Join(" ", result));
        }

        public static void Swap(Node node, ref Node head, ref Node tail)
        {
            var nextHead = node.Next ?? node;
            var nextTail = node.Previous ?? node;   // same as down commentS // return one that is not null

            //if (node.Next == null)
            //{
            //    nextHead = node;
            //}

            //if (node.Previous == null)
            //{
            //    nextTail = node;
            //}

            if (nextTail == node)
            {
                node.Next = null;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
            }

            if (nextHead == node)
            {
                node.Previous = null;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
            }

            nextHead.Previous = null;

            nextTail.Next = null;

            head = nextHead;
            tail = nextTail;
        }
    }

    class Node
    {
        public Node(int value, Node prev)
        {
            this.Value = value;
            this.Previous = prev;
            if (prev != null)
            {
                this.Previous.Next = this;
            }
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}
