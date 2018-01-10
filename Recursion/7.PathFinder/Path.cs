using System;
using System.Collections.Generic;

namespace _7.PathFinder
{
    public class Path
    {
        private readonly LinkedList<Position> positions;

        public Path()
        {
            this.positions = new LinkedList<Position>();
        }

        public Path(IEnumerable<Position> positions)
        {
            this.positions = new LinkedList<Position>(positions);
        }

        public ICollection<Position> AllPositions => new List<Position>(this.positions);

        public void AddPosition(Position position)
        {
            this.CheckPosition(position);
            this.positions.AddLast(position);
        }

        public void RemoveLast()
        {
            this.positions.RemoveLast();
        }

        public override string ToString()
        {
            return string.Join(", ", this.positions);
        }

        private void CheckPosition(Position position)
        {
            if (this.positions.Count > 1)
            {
                var prevPosition = this.positions.Last.Value;

                int distance = (int)Math.Sqrt(Math.Pow(prevPosition.X - position.X, 2) + Math.Pow(prevPosition.Y - position.Y, 2));

                if (distance != 1)
                {
                    throw new ArgumentException("Path positions should be consecutive.");
                }
            }
        }
    }
}
