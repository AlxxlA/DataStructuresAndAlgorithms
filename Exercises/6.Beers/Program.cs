using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _6.Beers
{
    class Program
    {
        static void Main()
        {
            var args = Console.ReadLine().Split().Select(int.Parse).ToList();

            int rows = args[0];
            int cols = args[1];
            int m = args[2];

            var graph = new Graph();

            var start = new Node("0;0", 0, 0);
            var end = new Node($"{rows};{cols}", rows - 1, cols - 1);

            graph.AddNode(start);
            graph.AddNode(end);

            AddNodes(graph, m);

            var result = FindShortestPath(graph, start, end);

            Console.WriteLine(result);
        }

        private static double FindShortestPath(Graph graph, Node start, Node end)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph.Nodes)
            {
                node.DistatnceTo = double.PositiveInfinity;
                node.IsProccesed = false;
                queue.Enqueue(node);
            }

            start.DistatnceTo = 0;
            queue.Remove(start);
            queue.Add(start);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.IsProccesed)
                {
                    continue;
                }

                if (double.IsPositiveInfinity(currentNode.DistatnceTo))
                {
                    break;
                }

                foreach (var node in graph.Nodes)
                {
                    if (node == currentNode || node.IsProccesed)
                    {
                        continue;
                    }

                    var distance = Math.Abs(currentNode.Row - node.Row) + Math.Abs(currentNode.Col - node.Col) + currentNode.DistatnceTo;
                    if (node.IsBeer)
                    {
                        distance -= 5;
                    }

                    if (node.DistatnceTo > distance)
                    {
                        queue.Remove(node);
                        node.DistatnceTo = distance;
                        queue.Add(node);
                    }
                }

                currentNode.IsProccesed = true;
            }

            var result = end.DistatnceTo;

            return result;
        }

        private static void AddNodes(Graph graph, int m)
        {
            for (int i = 0; i < m; i++)
            {
                var args = Console.ReadLine().Split().Select(int.Parse).ToList();

                var row = args[0];
                var col = args[1];

                var beerNode = new Node($"{row};{col}", row, col) { IsBeer = true };
                graph.AddNode(beerNode);
            }
        }
    }

    class Graph
    {
        public Graph()
        {
            this.Nodes = new List<Node>();
        }

        public void AddNode(string value, int row, int col)
        {
            this.Nodes.Add(new Node(value, row, col));
        }

        public void AddNode(Node node)
        {
            this.Nodes.Add(node);
        }

        public ICollection<Node> Nodes { get; set; }
    }

    class Node : IComparable<Node>
    {
        public Node(string value, int row, int col)
        {
            this.Value = value;
            this.Row = row;
            this.Col = col;
        }

        public string Value { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public double DistatnceTo { get; set; }

        public bool IsProccesed { get; set; }

        public bool IsBeer { get; set; }

        public int CompareTo(Node other)
        {
            var result = this.DistatnceTo.CompareTo(other.DistatnceTo);

            if (result == 0)
            {
                result = this.Value.CompareTo(other.Value);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Value}: [Row: {this.Row}; Col: {this.Col}], Distance {this.DistatnceTo}";
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> queue;

        public int Count
        {
            get { return this.queue.Count; }
        }

        public PriorityQueue()
        {
            this.queue = new OrderedBag<T>();
        }

        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }

        public T Dequeue()
        {
            return this.queue.RemoveFirst();
        }

        public void Remove(T node)
        {
            this.queue.Remove(node);
        }

        public void Add(T node)
        {
            this.queue.Add(node);
        }
    }
}
