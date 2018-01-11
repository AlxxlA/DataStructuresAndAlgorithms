using System;
using System.Collections.Generic;

namespace _7.PathFinder
{
    public static class PathFinder
    {
        private static IList<Path> allPaths;
        private static bool isPathFinded;
        private static Path path;

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

        private static void FindAllPaths(Maze maze, Position currentPosition, Position end, HashSet<Position> visited, Path currentPath)
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
                currentPath.AddPosition(currentPosition);
                allPaths.Add(new Path(currentPath.AllPositions));
                currentPath.RemoveLast();
                return;
            }

            visited.Add(currentPosition);
            currentPath.AddPosition(currentPosition);

            var leftPosition = new Position(currentPosition.X, currentPosition.Y - 1);
            var rightPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            var upPosition = new Position(currentPosition.X - 1, currentPosition.Y);
            var downPosition = new Position(currentPosition.X + 1, currentPosition.Y);

            FindAllPaths(maze, leftPosition, end, visited, currentPath);
            FindAllPaths(maze, rightPosition, end, visited, currentPath);
            FindAllPaths(maze, upPosition, end, visited, currentPath);
            FindAllPaths(maze, downPosition, end, visited, currentPath);

            visited.Remove(currentPosition);
            currentPath.RemoveLast();
        }

        public static Path FindPath(Maze maze, Position start, Position end)
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

            isPathFinded = false;
            path = new Path();

            // DFS method to find all paths
            FindPath(maze, start, end, new HashSet<Position>(), new Path());

            if (!isPathFinded)
            {
                throw new ArgumentException("End position is unreachable from givven start position.");
            }

            return path; // we only waht first finded currentPath
        }

        private static void FindPath(Maze maze, Position currentPosition, Position end, HashSet<Position> visited, Path currentPath)
        {
            if (isPathFinded)
            {
                return;
            }
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
                currentPath.AddPosition(currentPosition);
                path = new Path(currentPath.AllPositions);
                isPathFinded = true;
                return;
            }

            visited.Add(currentPosition);
            currentPath.AddPosition(currentPosition);

            var leftPosition = new Position(currentPosition.X, currentPosition.Y - 1);
            var rightPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            var upPosition = new Position(currentPosition.X - 1, currentPosition.Y);
            var downPosition = new Position(currentPosition.X + 1, currentPosition.Y);

            FindPath(maze, leftPosition, end, visited, currentPath);
            FindPath(maze, rightPosition, end, visited, currentPath);
            FindPath(maze, upPosition, end, visited, currentPath);
            FindPath(maze, downPosition, end, visited, currentPath);

            visited.Remove(currentPosition);
            currentPath.RemoveLast();
        }
    }
}
