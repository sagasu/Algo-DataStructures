using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Falling_Path_Sum
{
    internal class Minimum_Falling_Path_Sum
    {
        public int MinFallingPathSum(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int m = matrix.Length, n = matrix[0].Length;

            // dp[i,j]: min falling path sum ending at matrix[i,j]
            int[,] dp = new int[m, n];
            for (int j = 0; j < n; j++)
                dp[0, j] = matrix[0][j];

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int path1 = j - 1 < 0 ? Int32.MaxValue : dp[i - 1, j - 1];
                    int path2 = dp[i - 1, j];
                    int path3 = j + 1 >= n ? Int32.MaxValue : dp[i - 1, j + 1];
                    dp[i, j] = Math.Min(path1, Math.Min(path2, path3)) + matrix[i][j];
                }
            }

            int res = dp[m - 1, 0];
            for (int j = 0; j < n; j++)
                res = Math.Min(res, dp[m - 1, j]);

            return res;
        }
    }
}
