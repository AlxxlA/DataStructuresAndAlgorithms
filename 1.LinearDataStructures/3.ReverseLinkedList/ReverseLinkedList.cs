using System;
using System.Collections.Generic;

namespace _3.ReverseLinkedList
{
    class ReverseLinkedList
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();

            for (int i = 1; i < 5; i++)
            {
                linkedList.AddLast(i);
            }

            var reversedLinkedList = new LinkedList<int>();

            foreach (var item in linkedList)
            {
                reversedLinkedList.AddFirst(item);
            }

            foreach (var item in reversedLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}