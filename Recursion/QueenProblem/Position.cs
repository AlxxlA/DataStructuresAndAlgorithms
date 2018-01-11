namespace QueenProblem
{
    public struct Position
    {
        public Position(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"({this.X}; {this.Y})";
        }
    }
}
