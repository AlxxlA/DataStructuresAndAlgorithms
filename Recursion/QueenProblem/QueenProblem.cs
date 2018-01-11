using System;
using System.Collections.Generic;

namespace QueenProblem
{
    class QueenProblem
    {
        private static int solutionsFound = 0;
        private static HashSet<int> visitedRows;
        static void Main()
        {
            var board = new Board(8);

            visitedRows = new HashSet<int>();
            FindSolutions(board); // not very optimized, hang on 15x15 board

            Console.WriteLine($"Board size: {board.Size}x{board.Size}, Solutions count: {solutionsFound}");
        }

        private static void FindSolutions(Board board, int currentCol = 0)
        {
            if (currentCol >= board.Size) // solution is found
            {
                Console.WriteLine(board);
                Console.WriteLine();
                solutionsFound++;
                return;
            }

            for (int i = 0; i < board.Size; i++)
            {
                if (visitedRows.Contains(i))
                {
                    continue;
                }
                if (board.IsSafePosition(i, currentCol))
                {
                    visitedRows.Add(i);
                    board[i, currentCol] = 1;
                    FindSolutions(board, currentCol + 1);
                    board[i, currentCol] = 0;
                    visitedRows.Remove(i);
                }
            }
        }
    }
}
