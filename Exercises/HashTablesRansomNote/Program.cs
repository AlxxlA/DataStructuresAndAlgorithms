using System;
using System.Collections.Generic;

namespace HashTablesRansomNote
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int m = int.Parse(tokens[0]);
            int n = int.Parse(tokens[1]);

            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            var magazineWords = new Dictionary<string, int>();
            var noteWords = new Dictionary<string, int>();

            foreach (var word in magazine)
            {
                if (!magazineWords.ContainsKey(word))
                {
                    magazineWords.Add(word, 0);
                }
                magazineWords[word]++;
            }

            foreach (var word in ransom)
            {
                if (!noteWords.ContainsKey(word))
                {
                    noteWords.Add(word, 0);
                }
                noteWords[word]++;
            }

            foreach (var noteWord in noteWords)
            {
                if (!magazineWords.ContainsKey(noteWord.Key) || magazineWords[noteWord.Key] < noteWord.Value)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
        }
    }
}
