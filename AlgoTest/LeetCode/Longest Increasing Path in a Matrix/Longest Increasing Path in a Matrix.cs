using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_Increasing_Path_in_a_Matrix
{
    internal class Longest_Increasing_Path_in_a_Matrix
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var max = 0;
            var dp = Enumerable.Range(0, m).Select(i => Enumerable.Repeat(-1, n).ToArray()).ToArray();

            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                if (dp[i][j] == -1) dp[i][j] = Helper(matrix, i, j, dp);
                    
                max = Math.Max(max, dp[i][j]);
            }
            
            return max;
        }

        int Helper(int[][] matrix, int i, int j, int[][] dp)
        {
            if (dp[i][j] != -1) return dp[i][j];
            var x = matrix[i][j];

            var up = i - 1 >= 0 && matrix[i - 1][j] > x ? Helper(matrix, i - 1, j, dp) : 0;
            var down = i + 1 < matrix.Length && matrix[i + 1][j] > x ? Helper(matrix, i + 1, j, dp) : 0;
            var left = j - 1 >= 0 && matrix[i][j - 1] > x ? Helper(matrix, i, j - 1, dp) : 0;
            var right = j + 1 < matrix[0].Length && matrix[i][j + 1] > x ? Helper(matrix, i, j + 1, dp) : 0;

            return dp[i][j] = 1 + new[] { up, down, left, right }.Max();
        }
    }
}
