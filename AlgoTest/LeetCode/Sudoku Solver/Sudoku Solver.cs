using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Sudoku_Solver
{
    public class Sudoku_Solver
    {
        private bool[,] rows = new bool[9, 10],
            cols = new bool[9, 10],
            boxes = new bool[9, 10];

        public void SolveSudoku(char[][] board)
        {
            if (board == null || board.Length == 0)
                return;

            for (int i = 0; i < board.Length; i++)
            for (int j = 0; j < board[0].Length; j++)
                if (board[i][j] != '.')
                {
                    rows[i, board[i][j] - 48] = true;
                    cols[j, board[i][j] - 48] = true;
                    boxes[(i / 3) * 3 + j / 3, board[i][j] - 48] = true;
                }

            Helper(board, 0, 0);
        }

        private bool Helper(char[][] board, int i, int j)
        {
            while (i < 9 && board[i][j] != '.')
            {
                j++;

                if (j > 8)
                {
                    i++;
                    j = 0;
                }
            }

            if (i == 9)
                return true;

            for (int k = 1; k < 10; k++)
                if (!rows[i, k] && !cols[j, k] && !boxes[(i / 3) * 3 + j / 3, k])
                {
                    rows[i, k] = true;
                    cols[j, k] = true;
                    boxes[(i / 3) * 3 + j / 3, k] = true;
                    board[i][j] = (char)(k + 48);

                    if (Helper(board, i, j))
                        return true;

                    rows[i, k] = false;
                    cols[j, k] = false;
                    boxes[(i / 3) * 3 + j / 3, k] = false;
                    board[i][j] = '.';
                }

            return false;
        }
    }
}

