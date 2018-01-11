using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenProblem
{
    public class Board
    {
        private const string InvalidSizeMessage = "Board size cannot be less or equal to 0.";
        private const string InvalidPositionMessage = "Given position is out of bounds of board.";

        private readonly int[,] board;
        private int size;

        public Board(int size)
        {
            this.Size = size;
            this.board = new int[this.Size, this.Size];
        }

        public int Size
        {
            get => this.size;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidSizeMessage);
                }

                this.size = value;
            }
        }

        public int this[int x, int y]
        {
            get
            {
                this.ValidatePosition(x, y);
                return this.board[x, y];
            }
            set
            {
                this.ValidatePosition(x, y);
                this.board[x, y] = value;
            }
        }

        public int this[Position position]
        {
            get
            {
                this.ValidatePosition(position);
                return this.board[position.X, position.Y];
            }
            set
            {
                this.ValidatePosition(position);
                this.board[position.X, position.Y] = value;
            }
        }


        public bool IsSafePosition(Position position)
        {
            return this.IsSafePosition(position.X, position.Y);
        }

        public bool IsSafePosition(int x, int y)
        {
            this.ValidatePosition(x, y);

            // check row
            //for (int i = 0; i < this.Size; i++)
            //{
            //    if (this.board[i, y] == 1)
            //    {
            //        return false;
            //    }
            //}

            // check col
            //for (int i = 0; i < this.Size; i++)
            //{
            //    if (this.board[x, i] == 1)
            //    {
            //        return false;
            //    }
            //}

            // check upper-left diagonal
            int j = y;
            for (int i = x; i >= 0 && j >= 0; i--, j--)
            {
                if (this.board[i, j] == 1)
                {
                    return false;
                }
            }

            // check upper-right diagonal
            //j = y;
            //for (int i = x; i >= 0 && j < this.Size; i--, j++)
            //{
            //    if (this.board[i, j] == 1)
            //    {
            //        return false;
            //    }
            //}

            // check down-left diagonal
            j = y;
            for (int i = x; i < this.Size && j >= 0; i++, j--)
            {
                if (this.board[i, j] == 1)
                {
                    return false;
                }
            }

            // check down-right diagonal
            //j = y;
            //for (int i = x; i < this.Size && j < this.Size; i++, j++)
            //{
            //    if (this.board[i, j] == 1)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        public bool IsValidPosition(Position position)
        {
            if (position.X < 0 || position.X >= this.Size || position.Y < 0 || position.Y >= this.Size)
            {
                return false;
            }

            return true;
        }

        public bool IsValidPosition(int x, int y)
        {
            if (x < 0 || x >= this.Size || y < 0 || y >= this.Size)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (position.X < 0 || position.X >= this.Size || position.Y < 0 || position.Y >= this.Size)
            {
                throw new IndexOutOfRangeException(InvalidPositionMessage);
            }
        }

        public void ValidatePosition(int x, int y)
        {
            if (x < 0 || x >= this.Size || y < 0 || y >= this.Size)
            {
                throw new IndexOutOfRangeException(InvalidPositionMessage);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    result.Append(this.board[row, col] + " ");
                }
                result.AppendLine();
            }

            return result.ToString().Trim();
        }
    }
}
