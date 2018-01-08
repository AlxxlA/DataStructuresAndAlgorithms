using System;
using System.Collections.Generic;


namespace JediMeditationQueue
{
    class JediMeditationQueue
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] jedis = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();

            foreach (var jedi in jedis)
            {
                switch (jedi[0])
                {
                    case 'M':
                        masters.Enqueue(jedi);
                        break;
                    case 'K':
                        knights.Enqueue(jedi);
                        break;
                    case 'P':
                        padawans.Enqueue(jedi);
                        break;
                }
            }

            var result = new List<string>(n);

            result.AddRange(masters);
            result.AddRange(knights);
            result.AddRange(padawans);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}