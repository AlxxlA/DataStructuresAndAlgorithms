using System;
using System.Collections.Generic;

namespace GraphLibrary
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Neighbours = new Dictionary<string, Edge<T>>();
        }

        public T Value { get; set; }

        public IDictionary<string, Edge<T>> Neighbours { get; set; }

        internal bool IsVisited { get; set; }

        internal void AddNeighbour(Edge<T> edge)
        {
            if (!this.Neighbours.ContainsKey(edge.Name))
            {
                this.Neighbours.Add(edge.Name, edge);
            }
            else
            {
                throw new ArgumentException("Given neighbour already is connected.");
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
