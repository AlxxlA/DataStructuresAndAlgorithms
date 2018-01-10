using System;

namespace _7.PathFinder
{
    class Program
    {
        static void Main()
        {
            var mazeFilePath = @"...\...\Maze.txt";
            var maze = new Maze(mazeFilePath);

            Console.WriteLine(maze);

            var startPosition = new Position(0, 0);
            var endPosition = new Position(4, 4);

            var paths = PathFinder.FindAllPaths(maze, startPosition, endPosition);

            foreach (var path in paths)
            {
                Console.WriteLine(path);
            }
        }
    }
}
