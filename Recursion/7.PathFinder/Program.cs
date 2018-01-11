using System;

namespace _7.PathFinder
{
    class Program
    {
        static void Main()
        {
            var mazeFilePath = @"...\...\Maze.txt";
            var maze = new Maze(mazeFilePath);

            Console.WriteLine("Maze");
            Console.WriteLine(maze);
            Console.WriteLine();

            var startPosition = new Position(0, 0);
            var endPosition = new Position(4, 4);


            var paths = PathFinder.FindAllPaths(maze, startPosition, endPosition);

            Console.WriteLine("All paths:");
            foreach (var path in paths)
            {
                Console.WriteLine(path);
            }
            Console.WriteLine();

            var firstPathFinded = PathFinder.FindPath(maze, startPosition, endPosition);
            Console.WriteLine("First only one path:");
            Console.WriteLine(firstPathFinded);

        }
    }
}
