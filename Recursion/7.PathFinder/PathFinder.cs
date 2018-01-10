using System;
using System.Collections.Generic;

namespace _7.PathFinder
{
    public static class PathFinder
    {
        private static ICollection<Path> allPaths;

        public static IEnumerable<Path> FindAllPaths(Maze maze, Position start, Position end)
        {
            if (!maze.IsPassablePosition(start))
            {
                throw new ArgumentException("Start position is invalid.");
            }
            if (!maze.IsPassablePosition(end))
            {
                throw new ArgumentException("End position is unreachable.");
            }
            if (!maze.IsValidPosition(start))
            {
                throw new ArgumentException("Given start position is out of maze.");
            }
            if (!maze.IsValidPosition(end))
            {
                throw new ArgumentException("Given end position is out of maze.");
            }

            allPaths = new List<Path>();

            // DFS method to find all paths
            FindAllPaths(maze, start, end, new HashSet<Position>(), new Path());

            if (allPaths.Count == 0)
            {
                throw new ArgumentException("End position is unreachable from givven start position.");
            }

            return allPaths;
        }

        private static void FindAllPaths(Maze maze, Position currentPosition, Position end, HashSet<Position> visited, Path path)
        {
            if (!maze.IsValidPosition(currentPosition))
            {
                return;
            }
            if (visited.Contains(currentPosition))
            {
                return;
            }
            if (!maze.IsPassablePosition(currentPosition))
            {
                return;
            }

            if (currentPosition.Equals(end))
            {
                path.AddPosition(currentPosition);
                allPaths.Add(new Path(path.AllPositions));
                path.RemoveLast();
                return;
            }

            visited.Add(currentPosition);
            path.AddPosition(currentPosition);

            var leftPosition = new Position(currentPosition.X, currentPosition.Y - 1);
            var rightPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            var upPosition = new Position(currentPosition.X - 1, currentPosition.Y);
            var downPosition = new Position(currentPosition.X + 1, currentPosition.Y);

            FindAllPaths(maze, leftPosition, end, visited, path);
            FindAllPaths(maze, rightPosition, end, visited, path);
            FindAllPaths(maze, upPosition, end, visited, path);
            FindAllPaths(maze, downPosition, end, visited, path);

            visited.Remove(currentPosition);
            path.RemoveLast();
        }
    }
}
