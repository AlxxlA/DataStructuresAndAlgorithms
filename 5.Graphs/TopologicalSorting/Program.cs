using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class Program
    {
        static void Main()
        {
            var args = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = args[0];
            int m = args[1];

            var graph = new Graph<int>();

            FillGraph(graph, n);

            AddConnections(graph, m);

            var result = graph.TopologicalSort();

            Console.WriteLine(string.Join("\n", result));
        }

        private static void AddConnections(Graph<int> graph, int m)
        {
            for (int i = 0; i < m; i++)
            {
                var args = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int parent = args[0];
                int child = args[1];

                graph.AddConnection(parent, child);
            }
        }

        private static void FillGraph(Graph<int> graph, int n)
        {
            for (int i = 0; i < n; i++)
            {
                graph.AddNode(i);
            }
        }
    }


    class Graph<T>
    {
        public Graph()
        {
            this.Nodes = new SortedDictionary<T, Node<T>>();
        }

        public IDictionary<T, Node<T>> Nodes { get; set; }

        public void AddNode(T n)
        {
            if (!this.Nodes.ContainsKey(n))
            {
                this.Nodes.Add(n, new Node<T>(n));
            }
            else
            {
                throw new ArgumentException("Node already exist.");
            }
        }

        public void AddConnection(T parent, T child)
        {
            if (!this.Nodes.ContainsKey(parent))
            {
                this.Nodes.Add(parent, new Node<T>(parent));
            }
            if (!this.Nodes.ContainsKey(child))
            {
                this.Nodes.Add(child, new Node<T>(child));
            }

            var parentNode = this.Nodes[parent];
            var childNode = this.Nodes[child];

            parentNode.Children.Add(childNode);
            childNode.ParentCount++;
        }

        public IEnumerable<Node<T>> TopologicalSort()
        {
            var isAllPrinted = false;

            var result = new List<Node<T>>();

            while (!isAllPrinted)
            {
                isAllPrinted = true;

                foreach (var node in this.Nodes)
                {
                    var currentNode = node.Value;

                    if (currentNode.ParentCount == 0 && !currentNode.IsVisited)
                    {
                        isAllPrinted = false;
                        currentNode.IsVisited = true;
                        result.Add(currentNode);

                        foreach (var nodeChild in currentNode.Children)
                        {
                            nodeChild.ParentCount--;
                        }

                        break;
                    }
                }
            }

            return result;
        }
    }

    class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public bool IsVisited { get; set; }

        public int ParentCount { get; set; }

        public ICollection<Node<T>> Children { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
