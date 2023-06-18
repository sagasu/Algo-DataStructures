using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Increasing_Paths_in_a_Grid
{
    internal class Number_of_Increasing_Paths_in_a_Grid
    {
        public int CountPaths(int[][] grid)
        {
            var dp = new int[grid.Length][];
            for (var i = 0; i < grid.Length; i++)
                dp[i] = new int[grid[0].Length];
            

            var res = 0;
            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
                {
                    if (dp[i][j] == 0)
                        dp[i][j] = dfs(i, j, -1, grid, dp) % 1000000007;
                    
                    res = (res + dp[i][j]) % 1000000007;
                }
            
            return res;
        }

        private int dfs(int i, int j, int prev, int[][] grid, int[][] dp)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || prev >= grid[i][j])
                return 0;
            
            if (dp[i][j] != 0) return dp[i][j];
            
            return dp[i][j] = (1 + dfs(i + 1, j, grid[i][j], grid, dp) +
                               dfs(i - 1, j, grid[i][j], grid, dp) +
                               dfs(i, j + 1, grid[i][j], grid, dp) +
                               dfs(i, j - 1, grid[i][j], grid, dp)) % 1000000007;
        }
    }
}
