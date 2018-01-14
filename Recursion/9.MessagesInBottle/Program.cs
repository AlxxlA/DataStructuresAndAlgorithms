using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _9.MessagesInBottle
{
    class Program
    {
        private static StringBuilder sb = new StringBuilder();
        private static SortedDictionary<char, string> codes = new SortedDictionary<char, string>();
        private static string encryptedMessage;
        private static int counter = 0;

        static void Main()
        {
            encryptedMessage = Console.ReadLine();
            string cipher = Console.ReadLine();

            string pattern = "([A-Z])([0-9]+)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(cipher);

            foreach (Match match in matches)
            {
                var letter = match.Groups[1].ToString()[0];
                var code = match.Groups[2].ToString();

                if (!codes.ContainsKey(letter))
                {
                    codes.Add(letter, code);
                }
            }

            FindDecryptedMessage();

            Console.WriteLine(counter);
            Console.WriteLine(sb.ToString().Trim());
        }

        private static void FindDecryptedMessage(string currenMessage = "", int start = 0)
        {
            if (start >= encryptedMessage.Length)
            {
                sb.AppendLine(currenMessage);
                counter++;
                return;
            }
            var temp = currenMessage;

            foreach (var code in codes)
            {
                string letterCode = "";
                int codeLength = code.Value.Length;
                try
                {
                    letterCode = encryptedMessage.Substring(start, codeLength);
                }
                catch (Exception e)
                {
                }
                if (letterCode == code.Value)
                {
                    currenMessage += code.Key;
                    FindDecryptedMessage(currenMessage, start + codeLength);
                }

                currenMessage = temp;
            }
        }
    }
}
