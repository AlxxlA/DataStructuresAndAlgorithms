using System;
using System.Collections.Generic;
using System.Text;

namespace _10.Slogan
{
    class Program
    {
        private static bool isFind = false;
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var wordsAllowed = new HashSet<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                var slogan = Console.ReadLine();

                isFind = false;
                TestSlogan(slogan, wordsAllowed, new LinkedList<string>(), new HashSet<string>());
                if (!isFind)
                {
                    output.AppendLine("NOT VALID");
                }
            }

            Console.WriteLine(output);
        }

        private static void TestSlogan(string slogan, HashSet<string> wordsAllowed, LinkedList<string> usedWords, HashSet<string> imposibleSlogans)
        {
            if (slogan == string.Empty)
            {
                output.AppendLine(string.Join(" ", usedWords));
                isFind = true;
                return;
            }

            if (imposibleSlogans.Contains(slogan))
            {
                return;
            }

            foreach (var word in wordsAllowed)
            {
                if (slogan.StartsWith(word))
                {
                    usedWords.AddLast(word);

                    TestSlogan(slogan.Substring(word.Length), wordsAllowed, usedWords, imposibleSlogans);

                    if (isFind)
                    {
                        return;
                    }

                    usedWords.RemoveLast();
                }
            }

            imposibleSlogans.Add(slogan);
        }
    }
}
