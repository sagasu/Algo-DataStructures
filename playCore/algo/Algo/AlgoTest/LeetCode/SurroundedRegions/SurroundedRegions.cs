using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AlgoTest.LeetCode.SurroundedRegions
{
    class SurroundedRegions
    {
        public void Solve(char[][] board)
        {
            for (var i = 0; i < board.Length; i++)
            {
                MarkBoardRegions(board, i, 0);
                MarkBoardRegions(board, i, board[i].Length - 1);

                if (i == 0 || i == board.Length - 1)
                {
                    for (var j = 0; j < board[i].Length; j++)
                    {
                        MarkBoardRegions(board, i, j);
                    }
                }
            }

            for (var i = 0; i < board.Length; i++)
            for (var j = 0; j < board[i].Length; j++)
            {
                CaptureRegion(board, i, j);
                if (board[i][j] == '*')
                    board[i][j] = 'O';
            }
        }

        private void CaptureRegion(char[][] board, int row, int column)
        {
            //row < 0 || column < 0 || row > board.Length || column > board[row].Length ||
            if (row < 0 || column < 0 || row >= board.Length || column >= board[row].Length || board[row][column] == 'X' || board[row][column] == '*')
                return;

            board[row][column] = 'X';
            CaptureRegion(board, row + 1, column);
            CaptureRegion(board, row - 1, column);
            CaptureRegion(board, row, column + 1);
            CaptureRegion(board, row, column - 1);
        }

        private void MarkBoardRegions(char[][] board, int row, int column)
        {
            if (row < 0 || column < 0 || row >= board.Length || column >= board[row].Length || board[row][column] == 'X' || board[row][column] == '*')
                return;

            board[row][column] = '*';
            MarkBoardRegions(board, row + 1, column);
            MarkBoardRegions(board, row - 1, column);
            MarkBoardRegions(board, row, column + 1);
            MarkBoardRegions(board, row, column - 1);

        }
    }
}
