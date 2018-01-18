using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class Graph<T>
    {
        public Graph()
        {
            this.Nodes = new Dictionary<T, Node<T>>();
        }

        public Dictionary<T, Node<T>> Nodes { get; set; }

        public void AddNode(T nodeValue)
        {
            if (!this.Nodes.ContainsKey(nodeValue))
            {
                var newNode = new Node<T>(nodeValue);
                this.Nodes.Add(nodeValue, newNode);
            }
            else
            {
                throw new ArgumentException("Node already exist in graph.");
            }
        }

        public void AddNode(Node<T> node)
        {
            if (!this.Nodes.ContainsKey(node.Value))
            {
                this.Nodes.Add(node.Value, node);
            }
            else
            {
                throw new ArgumentException("Node already exist in graph.");
            }
        }

        public void AddNeighbourToNode(Node<T> node, Node<T> neighbour, string edgeName, decimal weight = 1, bool isDoubleLinked = true)
        {
            if (this.Nodes.ContainsKey(node.Value))
            {
                if (!node.Neighbours.ContainsKey(edgeName))
                {
                    var edge = new Edge<T>(edgeName, neighbour, weight);
                    node.Neighbours.Add(edgeName, edge);

                    if (isDoubleLinked)
                    {
                        if (!neighbour.Neighbours.ContainsKey(edgeName))
                        {
                            var neighbourEdge = new Edge<T>(edgeName, node, weight);
                            neighbour.Neighbours.Add(edgeName, neighbourEdge);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Node connection already exist.");
                }
            }
            else
            {
                throw new ArgumentException("Node does not exist in graph.");
            }
        }

        public void AddNeighbourToNode(T nodeValue, T neighbourValue, string edgeName, decimal weight = 1, bool isDoubleLinked = true)
        {
            if (this.Nodes.ContainsKey(nodeValue))
            {
                var node = this.Nodes[nodeValue];

                Node<T> neighbour;

                if (this.Nodes.ContainsKey(neighbourValue))
                {
                    neighbour = this.Nodes[neighbourValue];
                }
                else
                {
                    neighbour = new Node<T>(neighbourValue);
                    this.Nodes.Add(neighbourValue, neighbour);
                }

                var edge = new Edge<T>(edgeName, neighbour, weight);
                node.Neighbours.Add(edgeName, edge);

                if (isDoubleLinked)
                {
                    if (!neighbour.Neighbours.ContainsKey(edgeName))
                    {
                        var neighbourEdge = new Edge<T>(edgeName, node, weight);
                        neighbour.Neighbours.Add(edgeName, neighbourEdge);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Node does not exist in graph.");
            }
        }

        public void TraverceDfs()
        {
            foreach (var node in this.Nodes.Values)
            {
                if (!node.IsVisited)
                {
                    var list = new List<Node<T>>();
                    this.Dfs(node, list);
                }
            }
        }

        private void Dfs(Node<T> node, List<Node<T>> nodes)
        {
            if (node.IsVisited)
            {
                return;
            }

            node.IsVisited = true;
            nodes.Add(node);

            foreach (var nodeNeighbour in node.Neighbours)
            {
                this.Dfs(nodeNeighbour.Value.Neighbour, nodes);
            }

            Console.WriteLine(string.Join(" => ", nodes));

            nodes.Remove(node);
        }
    }
}
