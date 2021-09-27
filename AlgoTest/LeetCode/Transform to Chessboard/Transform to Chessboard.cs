using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Transform_to_Chessboard
{
    class Transform_to_Chessboard
    {
        public int MovesToChessboard(int[][] board)
        {
            int n = board.Length, rs = 0, cs = 0, ro = 0, co = 0; ;
            for (var i = 0; i < n; i++)
            {
                co += board[0][i];
                ro += board[i][0];
                if (board[0][i] != i % 2) cs++;
                if (board[i][0] != i % 2) rs++;
                for (var j = 0; j < n; j++)
                {
                    if ((board[0][0] ^ board[i][0] ^ board[0][j] ^ board[i][j]) > 0) return -1; //must be 4 zeros or 2 ones 2 zeros or 4 ones.
                }
            }
            if (co != n / 2 && co != (n + 1) / 2) return -1;
            if (ro != n / 2 && ro != (n + 1) / 2) return -1;
            if (n % 2 == 1)
            {
                if (rs % 2 == 1) rs = n - rs;
                if (cs % 2 == 1) cs = n - cs;
            }
            else
            {
                rs = Math.Min(rs, n - rs);
                cs = Math.Min(cs, n - cs);
            }
            return (rs + cs) / 2;
        }
    }
}
