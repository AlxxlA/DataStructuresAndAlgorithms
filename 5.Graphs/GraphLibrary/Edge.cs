namespace GraphLibrary
{
    public class Edge<T>
    {
        public Edge(string name, Node<T> neighbour, decimal weight)
        {
            this.Name = name;
            this.Neighbour = neighbour;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public Node<T> Neighbour { get; set; }

        public decimal Weight { get; set; }
    }
}
