using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridges
{
    class Program
    {
        static void Main()
        {
            var args = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nodesCount = args[0];
            int edgesCount = args[1];

            var graph = new Graph();

            FillGraph(graph, nodesCount);
            AddConnections(graph, edgesCount);

            int minWeight = int.Parse(Console.ReadLine());

            var result = MinBridges(graph, minWeight);

            Console.WriteLine(result);
        }

        private static int MinBridges(Graph graph, int weight)
        {
            var componentsCount = 0;

            foreach (var node in graph.Nodes.Values)
            {
                if (!node.IsVisited)
                {
                    DFS(node, weight);
                    componentsCount++;
                }
            }

            return componentsCount - 1;
        }

        private static void DFS(Node node, int weight)
        {
            if (node.IsVisited)
            {
                return;
            }

            node.IsVisited = true;

            foreach (var edge in node.Links.Values)
            {
                if (edge.Weight >= weight)
                {
                    DFS(edge.Target, weight);
                }
            }
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
            this.Nodes = new Dictionary<int, Node>();
        }

        public void AddNode(int n)
        {
            if (!this.Nodes.ContainsKey(n))
            {
                this.Nodes.Add(n, new Node(n));
            }
            else
            {
                throw new ArgumentException("Node already exist.");
            }
        }

        public void AddConnection(int start, int target, int weight)
        {
            var startNode = this.Nodes[start];
            var targetNode = this.Nodes[target];

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

        public IDictionary<int, Node> Nodes { get; set; }
    }

    class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Links = new Dictionary<int, Edge>();
        }

        public int Value { get; set; }

        public bool IsVisited { get; set; }

        public IDictionary<int, Edge> Links { get; set; }
    }

    class Edge
    {
        public Edge(int weight, Node target)
        {
            this.Weight = weight;
            this.Target = target;
        }

        public int Weight { get; set; }

        public Node Target { get; set; }
    }
}
