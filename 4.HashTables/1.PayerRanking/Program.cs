using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace _1.PayerRanking
{
    class Program
    {
        private static BigList<Player> ranking = new BigList<Player>();

        private static Dictionary<string, OrderedSet<Player>> playersByType = new Dictionary<string, OrderedSet<Player>>();

        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            var command = Console.ReadLine();

            while (command != "end")
            {
                var commandArgs = command.Split();

                var commandName = commandArgs[0];

                switch (commandName)
                {
                    case "add":
                        Add(commandArgs);
                        break;
                    case "ranklist":
                        Ranklist(commandArgs);
                        break;
                    case "find":
                        Find(commandArgs);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.Write(output);
        }

        private static void Add(string[] commandArgs)
        {
            var playerName = commandArgs[1];
            var playerType = commandArgs[2];
            var playerAge = int.Parse(commandArgs[3]);
            var playerRank = int.Parse(commandArgs[4]);

            var player = new Player(playerName, playerType, playerAge);

            ranking.Insert(playerRank - 1, player);

            if (!playersByType.ContainsKey(playerType))
            {
                playersByType[playerType] = new OrderedSet<Player>();
            }

            var typePlayers = playersByType[playerType];
            typePlayers.Add(player);

            if (typePlayers.Count > 5)
            {
                typePlayers.RemoveLast();
            }

            output.AppendLine($"Added player {playerName} to position {playerRank}");
        }

        private static void Ranklist(string[] commandArgs)
        {
            var start = int.Parse(commandArgs[1]) - 1;
            var end = int.Parse(commandArgs[2]);

            var range = ranking.Range(start, end - start);

            int rank = start + 1;

            for (int i = 0; i < range.Count; i++)
            {
                if (i == range.Count - 1)
                {
                    output.AppendLine($"{rank + i}. {range[i]}");
                    break;
                }
                output.Append($"{rank + i}. {range[i]}; ");
            }
        }

        private static void Find(string[] commandArgs)
        {
            var type = commandArgs[1];

            if (playersByType.ContainsKey(type))
            {
                var result = playersByType[type];
                output.Append($"Type {type}: ");
                foreach (var player in result)
                {
                    output.Append($"{player}; ");
                }
                output.Remove(output.Length - 2, 2);
                output.AppendLine();
            }
            else
            {
                output.AppendLine($"Type {type}: ");
            }
        }
    }

    public struct Player : IComparable<Player>
    {
        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name}({this.Age})";
        }

        public int CompareTo(Player other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = other.Age.CompareTo(this.Age);
            }

            return result;
        }
    }
}
