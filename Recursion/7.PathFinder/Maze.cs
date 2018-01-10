using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _7.PathFinder
{
    public class Maze
    {
        private const string InvalidRowsCountMessage = "Maze rows cannot be less or equal to 0.";
        private const string InvalidColsCountMessage = "Maze cols cannot be less or equal to 0.";
        private const string InvalidFilePathMessage = "Maze file was not found.";
        private const string InvalidPositionMessage = "Given position is out of bounds of maze.";
        private const string InvalidDimensionCountMessage = "Maze dimensions should be two.";
        private const string DimensionsNotIntMessage = "Maze dimension should be integer.";
        private const string InconsistentColsCountMessage = "Inconsistent cols count.";
        private const string TileNotIntegerMessage = "Maze tile should be integer.";
        private const string XCoordinateOutOfRangeMessage = "Given x coordinate is out of bounds of maze.";
        private const string YCoordinateOutOfRangeMessage = "Given y coordinate is out of bounds of maze.";

        private int[,] maze;
        private int rows;
        private int cols;
        private string mazeFilePath;

        public Maze()
        {
            this.GenerateRandomMaze();
        }

        public Maze(int rows, int cols)
        {
            this.GenerateRandomMaze(rows, cols);
        }

        public Maze(string filePath)
        {
            this.MazeFilePath = filePath;
            this.GenerateMazeFromFile();
        }

        public int Rows
        {
            get => this.rows;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidRowsCountMessage);
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get => this.cols;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidColsCountMessage);
                }

                this.cols = value;
            }
        }

        public string MazeFilePath
        {
            get => this.mazeFilePath;
            private set
            {
                if (!File.Exists(value))
                {
                    throw new FileNotFoundException(InvalidFilePathMessage);
                }

                this.mazeFilePath = value;
            }
        }

        public int this[int x, int y]
        {
            get
            {
                this.ValidateCoordonates(x, y);
                return this.maze[x, y];
            }
            set
            {
                this.ValidateCoordonates(x, y);
                this.maze[x, y] = value;
            }
        }

        public int this[Position position]
        {
            get
            {
                this.ValidatePosition(position);
                return this.maze[position.X, position.Y];
            }
            set
            {
                this.ValidatePosition(position);
                this.maze[position.X, position.Y] = value;
            }
        }

        public bool IsPassablePosition(Position position)
        {
            return this[position] == 0;
        }

        public bool IsValidPosition(Position position)
        {
            if (position.X < 0 || position.X >= this.Rows || position.Y < 0 || position.Y >= this.Cols)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (position.X < 0 || position.X >= this.Rows || position.Y < 0 || position.Y >= this.Cols)
            {
                throw new IndexOutOfRangeException(InvalidPositionMessage);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this.maze[row, col] + " ");
                }
                result.AppendLine();
            }

            return result.ToString().Trim();
        }

        private void GenerateRandomMaze()
        {
            var random = new Random();

            int r = random.Next(1, 100);
            int c = random.Next(1, 100);

            this.GenerateRandomMaze(r, c);
        }

        private void GenerateRandomMaze(int r, int c)
        {
            this.Rows = r;
            this.Cols = c;

            this.maze = new int[this.Rows, this.Cols];

            var random = new Random();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    int rand = random.Next(0, 101);

                    if (rand <= 33)
                    {
                        this.maze[row, col] = 1;
                    }
                }
            }
        }

        private void GenerateMazeFromFile()
        {
            int lineNumber = 0;

            using (var reader = new StreamReader(this.MazeFilePath))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    string[] args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // on the first line of file is dimensions e.g. 10(rows) 15(cols)
                    if (lineNumber == 0)
                    {
                        if (args.Length != 2)
                        {
                            throw new ArgumentException(InvalidDimensionCountMessage);
                        }

                        try
                        {
                            int parsedRows = int.Parse(args[0]);
                            int parsedCols = int.Parse(args[1]);

                            this.Rows = parsedRows;
                            this.Cols = parsedCols;
                            this.maze = new int[this.Rows, this.Cols];
                        }
                        catch (FormatException)
                        {
                            throw new FormatException(DimensionsNotIntMessage);
                        }
                    }
                    else
                    {
                        if (args.Length != this.Cols) // expect line in format: row col tileType
                        {
                            throw new IndexOutOfRangeException(InconsistentColsCountMessage);
                        }
                        try
                        {
                            int[] tiles = args.Select(int.Parse).ToArray();

                            for (int j = 0; j < this.Cols; j++)
                            {
                                this.maze[lineNumber - 1, j] = tiles[j];
                            }
                        }
                        catch (FormatException)
                        {
                            throw new FormatException(TileNotIntegerMessage);
                        }
                    }

                    lineNumber++;

                    line = reader.ReadLine();
                }
            }
        }

        private void ValidateCoordonates(int x, int y)
        {
            if (x < 0 || x >= this.Rows)
            {
                throw new IndexOutOfRangeException(XCoordinateOutOfRangeMessage);
            }
            if (y < 0 || y >= this.Cols)
            {
                throw new IndexOutOfRangeException(YCoordinateOutOfRangeMessage);
            }
        }
    }
}
