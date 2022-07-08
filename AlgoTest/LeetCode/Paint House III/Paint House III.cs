using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Paint_House_III
{
    internal class Paint_House_III
    {
        public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {
            var dp = new int[m][][];
            for (var i = 0; i < m; i++)
            {
                dp[i] = new int[n][];
                for (var j = 0; j < n; j++)
                    dp[i][j] = Enumerable.Repeat(int.MaxValue, m + 1).ToArray();
                
            }

            if (houses[0] == 0)
                for (var j = 0; j < n; j++) dp[0][j][1] = cost[0][j];
            else
                dp[0][houses[0] - 1][1] = 0;
            

            for (var i = 1; i < m; i++)
            for (var j = 0; j < n; j++)
            for (var k = 1; k <= m; k++)
                if (dp[i - 1][j][k] != int.MaxValue)
                {
                    if (houses[i] == 0)
                    {
                        for (var l = 0; l < n; l++)
                        {
                            var newk = k + (l == j ? 0 : 1);
                            dp[i][l][newk] = Math.Min(dp[i][l][newk], dp[i - 1][j][k] + cost[i][l]);
                        }
                    }
                    else
                    {
                        var l = houses[i] - 1;
                        var newk = k + (l == j ? 0 : 1);
                        dp[i][l][newk] = Math.Min(dp[i][l][newk], dp[i - 1][j][k]);
                    }
                }
            
            var res = int.MaxValue;
            for (var i = 0; i < n; i++)
                res = Math.Min(res, dp[m - 1][i][target]);
            
            return res == int.MaxValue ? -1 : res;
        }
    }
}
