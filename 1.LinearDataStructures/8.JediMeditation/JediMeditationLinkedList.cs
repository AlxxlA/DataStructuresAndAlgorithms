using System;
using System.Collections.Generic;

namespace _8.JediMeditation
{
    class JediMeditationLinkedList
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] jedis = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new LinkedList<string>();

            LinkedListNode<string> master = null;
            LinkedListNode<string> knight = null;
            LinkedListNode<string> padawan = null;

            foreach (var jedi in jedis)
            {
                switch (jedi[0])
                {
                    case 'M':
                        var newMaster = new LinkedListNode<string>(jedi);
                        if (master == null)
                        {
                            result.AddFirst(newMaster);
                        }
                        else
                        {
                            result.AddAfter(master, newMaster);
                        }
                        master = newMaster;
                        break;
                    case 'K':
                        var newKnight = new LinkedListNode<string>(jedi);
                        if (knight == null)
                        {
                            if (master == null)
                            {
                                result.AddFirst(newKnight);
                            }
                            else
                            {
                                result.AddAfter(master, newKnight);
                            }
                        }
                        else
                        {
                            result.AddAfter(knight, newKnight);
                        }
                        knight = newKnight;
                        break;
                    case 'P':
                        var newPadawan = new LinkedListNode<string>(jedi);
                        if (padawan == null)
                        {
                            if (knight == null && master == null)
                            {
                                result.AddFirst(newPadawan);
                            }
                            else if (knight != null)
                            {
                                result.AddAfter(knight, newPadawan);
                            }
                            else
                            {
                                result.AddAfter(master, newPadawan);
                            }
                        }
                        else
                        {
                            result.AddAfter(padawan, newPadawan);
                        }
                        padawan = newPadawan;
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
