using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.UnitsOfWork
{
    class Program
    {
        private static Dictionary<string, Unit> units = new Dictionary<string, Unit>();
        private static SortedSet<Unit> unitsByPower = new SortedSet<Unit>();
        private static Dictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();

        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            string command = Console.ReadLine();

            while (command != "end")
            {
                var commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "add":
                        Add(commandArgs);
                        break;
                    case "remove":
                        Remove(commandArgs);
                        break;
                    case "find":
                        Find(commandArgs);
                        break;
                    case "power":
                        Power(commandArgs);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(output);
        }

        private static void Add(string[] commandArgs)
        {
            var name = commandArgs[1];
            var type = commandArgs[2];
            var attack = int.Parse(commandArgs[3]);

            if (!units.ContainsKey(name))
            {
                var unit = new Unit(name, type, attack);

                units.Add(name, unit);
                unitsByPower.Add(unit);

                if (!unitsByType.ContainsKey(type))
                {
                    unitsByType.Add(type, new SortedSet<Unit>());
                }

                unitsByType[type].Add(unit);

                output.AppendLine(string.Format("SUCCESS: {0} added!", name));
            }
            else
            {
                output.AppendLine(string.Format("FAIL: {0} already exists!", name));
            }
        }

        private static void Remove(string[] commandArgs)
        {
            var name = commandArgs[1];

            if (units.ContainsKey(name))
            {
                var unit = units[name];

                units.Remove(name);
                unitsByPower.Remove(unit);
                unitsByType[unit.Type].Remove(unit);

                output.AppendLine(string.Format("SUCCESS: {0} removed!", name));
            }
            else
            {
                output.AppendLine(string.Format("FAIL: {0} could not be found!", name));
            }
        }

        private static void Find(string[] commandArgs)
        {
            var type = commandArgs[1];

            if (unitsByType.ContainsKey(type))
            {
                var result = unitsByType[type].Take(10);
                output.AppendLine(string.Format("RESULT: {0}", string.Join(", ", result)));
            }
            else
            {
                output.AppendLine("RESULT: ");
            }
        }

        private static void Power(string[] commandArgs)
        {
            var count = int.Parse(commandArgs[1]);

            var result = unitsByPower.Take(count);

            output.AppendLine(string.Format("RESULT: {0}", string.Join(", ", result)));
        }
    }

    class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(Unit other)
        {
            var result = other.Attack.CompareTo(this.Attack);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
