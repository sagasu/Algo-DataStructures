using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Out_of_Boundary_Paths
{
    internal class Out_of_Boundary_Paths
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            var dp = new int[m, n, maxMove + 1];
            var dir = new int[,] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            for (var k = 0; k <= maxMove; k++)
                dp[i, j, k] = -1;

            return Solve( maxMove, startRow, startColumn);


            int Solve(int maxMove, int startRow, int startColumn)
            {
                if (startColumn < 0 || startRow < 0 || startRow >= m || startColumn >= n) return 1;

                if (maxMove <= 0) return 0;

                if (dp[startRow, startColumn, maxMove] != -1) return dp[startRow, startColumn, maxMove];

                long ans = 0;

                for (var i = 0; i < dir.GetLength(0); i++)
                    ans = (ans + Solve(maxMove - 1, startRow + dir[i, 0], startColumn + dir[i, 1])) % 1000000007;

                dp[startRow, startColumn, maxMove] = (int)ans;
                return dp[startRow, startColumn, maxMove];
            }
        }
    }
}
