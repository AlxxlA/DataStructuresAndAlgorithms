using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elevators
{
    class Program
    {
        private static Dictionary<int, SortedSet<int>> graph = new Dictionary<int, SortedSet<int>>();
        private static Dictionary<int, int> higherRank = new Dictionary<int, int>();
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            var nodeCount = int.Parse(Console.ReadLine());

            var connections = Console.ReadLine().Split().Select(int.Parse);

            FillGaraph(nodeCount);
            AddConnections(connections);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var start = args[0];
                var end = args[1];

                FindPath(start, end);
            }

            Console.Write(output);
        }

        private static void FindPath(int start, int end)
        {
            if (start == end)
            {
                output.AppendLine("You are there");
                return;
            }

            var path = FindShortestPath(start, end).ToList();

            var min = path.Min();

            if (path.Count > 2)
            {
                var second = path[1];
                var last = path[path.Count - 2];

                if (higherRank[start] == second && higherRank[end] == last)
                {
                    bool isClimbing = higherRank[start] == second;

                    for (int i = 1; i < path.Count; i++)
                    {
                        if (path[i] != end)
                        {
                            bool currentDirection = higherRank[path[i]] == path[i + 1];

                            if (currentDirection != isClimbing)
                            {
                                min = path[i];
                                break;
                            }
                        }
                    }

                    output.AppendLine($"Through {min}");
                }
                else
                {
                    output.AppendLine("Directly");
                }
            }
            else
            {
                output.AppendLine("Directly");
            }
        }

        private static IEnumerable<int> FindShortestPath(int start, int end)
        {
            var queue = new Queue<int>();
            var paths = new Queue<List<int>>();

            var path = new List<int>();
            path.Add(start);

            paths.Enqueue(path);

            queue.Enqueue(start);

            var visited = new bool[graph.Count];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var currentPath = paths.Dequeue();

                visited[current] = true;

                if (current == end)
                {
                    return currentPath;
                }

                foreach (var neighbour in graph[current])
                {
                    if (!visited[neighbour])
                    {
                        currentPath.Add(neighbour);
                        var nextPath = new List<int>(currentPath);
                        queue.Enqueue(neighbour);
                        paths.Enqueue(nextPath);
                        currentPath.RemoveAt(currentPath.Count - 1);
                    }
                }
            }

            return new List<int>();
        }

        private static void AddConnections(IEnumerable<int> connections)
        {
            int nodeValue = 1;

            higherRank.Add(0, -1);
            foreach (var connection in connections)
            {
                higherRank.Add(nodeValue, connection);
                graph[nodeValue].Add(connection);
                graph[connection].Add(nodeValue);
                nodeValue++;
            }
        }

        private static void FillGaraph(int nodeCount)
        {
            for (int i = 0; i < nodeCount; i++)
            {
                graph.Add(i, new SortedSet<int>());
            }
        }
    }
}
