using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.As_Far_from_Land_as_Possible
{
    internal class As_Far_from_Land_as_Possible
    {
        public int MaxDistance(int[][] grid)
        {
            var dp = new int[grid.Length, grid.Length];
            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid.Length; j++)
                dp[i, j] = (grid[i][j] == 1) ? 0 : int.MaxValue;
                
            

            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid.Length; j++)
                    if (grid[i][j] == 0)
                    {
                        if (j > 0 && dp[i, j - 1] != int.MaxValue) { dp[i, j] = Math.Min(dp[i, j], 1 + dp[i, j - 1]); }
                        if (i > 0 && dp[i - 1, j] != int.MaxValue) { dp[i, j] = Math.Min(dp[i, j], 1 + dp[i - 1, j]); }
                    }
                
            var result = 0;
            for (var i = grid.Length - 1; i >= 0; i--)
            for (var j = grid.Length - 1; j >= 0; j--)
                    if (grid[i][j] == 0)
                    {
                        if (j < grid.Length - 1 && dp[i, j + 1] != int.MaxValue) { dp[i, j] = Math.Min(dp[i, j], 1 + dp[i, j + 1]); }
                        if (i < grid.Length - 1 && dp[i + 1, j] != int.MaxValue) { dp[i, j] = Math.Min(dp[i, j], 1 + dp[i + 1, j]); }
                        if (dp[i, j] != int.MaxValue && result < dp[i, j]) { result = dp[i, j]; }
                    }
            
            return (result == 0) ? -1 : result;
        }
    }
}
