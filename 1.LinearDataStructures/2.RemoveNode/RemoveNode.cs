using System;

namespace _2.RemoveNode
{
    class RemoveNode
    {
        static void Main()
        {
            var head = new ListNode<int>(1);
            var current = head;

            for (int i = 2; i < 10; i++)
            {
                current.Next = new ListNode<int>(i);
                current = current.Next;
            }

            Remove(head.Next);
            Print(head);
        }

        static void Print<T>(ListNode<T> node)
        {
            var current = node;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        static void Remove<T>(ListNode<T> node)
        {
            var next = node.Next;

            if (next == null)
            {
                throw new ArgumentException("Cannot delite tail.");
            }

            node.Value = next.Value;
            node.Next = next.Next;
        }
    }

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
    }
}