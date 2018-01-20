using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FriendsInNeed
{
    class Program
    {
        static void Main()
        {
            var args = Console.ReadLine().Split().Select(int.Parse).ToList();

            int nodes = args[0];
            int edges = args[1];
            int hospitalsCount = args[2];

            var starts = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));

            var graph = new Graph();

            FillGraph(graph, nodes);
            AddConnections(graph, edges);

            var min = double.MaxValue;
            foreach (var start in starts)
            {
                var result = FindShortestPath(graph, start, starts);

                if (min > result)
                {
                    min = result;
                }

            }

            Console.WriteLine(min);
        }

        private static double FindShortestPath(Graph graph, int start, HashSet<int> invalidPoints)
        {
            foreach (var city in graph.Cities.Values)
            {
                city.DistatnceTo = double.PositiveInfinity;
                city.IsProccesed = false;
            }

            var startNode = graph.Cities[start];
            startNode.DistatnceTo = 0;

            var queue = new PriorityQueue<Node>();

            foreach (var city in graph.Cities.Values)
            {
                queue.Enqueue(city);
                city.IsProccesed = false;
            }

            while (queue.Count > 0)
            {
                var currentCity = queue.Dequeue();

                currentCity.IsProccesed = true;
                if (double.IsPositiveInfinity(currentCity.DistatnceTo))
                {
                    break;
                }

                foreach (var edge in currentCity.Links.Values)
                {
                    var neighbour = edge.Target;

                    if (!neighbour.IsProccesed && neighbour.DistatnceTo > currentCity.DistatnceTo + edge.Weight)
                    {
                        queue.Remove(neighbour);
                        neighbour.DistatnceTo = currentCity.DistatnceTo + edge.Weight;
                        neighbour.Previous = currentCity;
                        queue.Add(neighbour);
                    }
                }

                currentCity.IsProccesed = true;
            }

            double result = 0;

            foreach (var node in graph.Cities.Values)
            {
                if (!invalidPoints.Contains(node.Value))
                {
                    result += node.DistatnceTo;
                }
            }

            return result;
        }

        private static void AddConnections(Graph graph, int m)
        {
            for (int i = 0; i < m; i++)
            {
                var args = Console.ReadLine().Split().Select(int.Parse).ToList();

                var from = args[0];
                var to = args[1];
                var distance = args[2];

                graph.AddConnection(from, to, distance);
                graph.AddConnection(to, from, distance);
            }
        }

        private static void FillGraph(Graph graph, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                graph.AddNode(i);
            }
        }
    }

    class Graph
    {
        public Graph()
        {
            this.Cities = new Dictionary<int, Node>();
        }

        public void AddNode(int n)
        {
            if (!this.Cities.ContainsKey(n))
            {
                this.Cities.Add(n, new Node(n));
            }
            else
            {
                throw new ArgumentException("Node already exist.");
            }
        }

        public void AddConnection(int start, int target, int weight)
        {
            var startNode = this.Cities[start];
            var targetNode = this.Cities[target];

            var link = new Edge(weight, targetNode);

            if (startNode.Links.ContainsKey(target))
            {
                if (startNode.Links[target].Weight > weight)
                {
                    startNode.Links[target] = link;
                }
            }
            else
            {
                startNode.Links.Add(target, link);
            }
        }

        public IDictionary<int, Node> Cities { get; set; }
    }

    class Node : IComparable<Node>
    {
        public Node(int value)
        {
            this.Value = value;
            this.Links = new Dictionary<int, Edge>();
            this.DistatnceTo = int.MaxValue;
        }

        public int Value { get; set; }

        public double DistatnceTo { get; set; }

        public Node Previous { get; set; }

        public bool IsProccesed { get; set; }

        public IDictionary<int, Edge> Links { get; set; }

        public int CompareTo(Node other)
        {
            var result = this.DistatnceTo.CompareTo(other.DistatnceTo);

            if (result == 0)
            {
                result = this.Value.CompareTo(other.Value);
            }

            return result;
        }
    }

    class Edge
    {
        public Edge(int weight, Node target)
        {
            this.Weight = weight;
            this.Target = target;
        }

        public double Weight { get; set; }

        public Node Target { get; set; }
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
