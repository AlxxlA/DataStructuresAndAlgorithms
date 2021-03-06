﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Diameter
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var graph = new Graph();

            FillGraph(graph, n);

            AddConnections(graph, n - 1);

            var longestRandom = FindLongestPath(graph, 1);

            var longestPath = FindLongestPath(graph, longestRandom);

            Console.WriteLine(graph.Cities[longestPath].DistatnceTo);
        }

        private static int FindLongestPath(Graph graph, int start)
        {
            foreach (var city in graph.Cities.Values)
            {
                city.DistatnceTo = 0;
                city.IsProccesed = false;
            }

            var startNode = graph.Cities[start];
            startNode.DistatnceTo = 0;

            var stack = new Stack<Node>();

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                currentNode.IsProccesed = true;

                foreach (var edge in currentNode.Links.Values)
                {
                    var child = edge.Target;
                    if (!child.IsProccesed)
                    {
                        child.DistatnceTo += currentNode.DistatnceTo + edge.Weight;
                        stack.Push(child);
                    }
                }
            }

            var maxDistance = int.MinValue;
            var maxNode = int.MinValue;

            foreach (var city in graph.Cities.Values)
            {
                if (city.DistatnceTo > maxDistance)
                {
                    maxDistance = city.DistatnceTo;
                    maxNode = city.Value;
                }
            }

            return maxNode;
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
            for (int i = 0; i < n; i++)
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

        public int DistatnceTo { get; set; }

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

        public int Weight { get; set; }

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
