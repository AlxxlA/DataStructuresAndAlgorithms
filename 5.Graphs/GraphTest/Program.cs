using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphTest
{
    class Program
    {
        static void Main()
        {
            var graph = new Graph<int>();

            Console.WriteLine("Enter number of nodes.");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                graph.AddNode(i);
            }

            Console.WriteLine("Enter number of connections");

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var commandArgs = Console.ReadLine().Split();

                var nodeValue = int.Parse(commandArgs[0]);
                var nodeNeighbour = int.Parse(commandArgs[1]);
                var edge = commandArgs[2];
                decimal weight = 1;
                bool isDoubleLinked = true;

                if (commandArgs.Length == 4)
                {
                    weight = decimal.Parse(commandArgs[3]);
                }
                if (commandArgs.Length == 5)
                {
                    weight = decimal.Parse(commandArgs[3]);
                    isDoubleLinked = bool.Parse(commandArgs[4]);
                }

                graph.AddNeighbourToNode(nodeValue, nodeNeighbour, edge, weight, isDoubleLinked);
            }

            graph.TraverceDfs();

        }
    }
}
