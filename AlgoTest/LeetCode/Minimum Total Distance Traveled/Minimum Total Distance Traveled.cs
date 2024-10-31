using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Total_Distance_Traveled;

public class Minimum_Total_Distance_Traveled
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        var sortedRobots = robot.OrderBy(x => x).ToList();
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));

        var n = sortedRobots.Count;
        var m = factory.Length;
        
        var dp = new long[n + 1, m + 1];
        for (var i = 0; i <= n; i++) 
            for (var j = 0; j <= m; j++) 
                dp[i, j] = long.MaxValue / 2;
            
        
        
        dp[0, 0] = 0;

        for (var j = 1; j <= m; j++) {
            dp[0, j] = 0; 
            
            for (var i = 1; i <= n; i++) {
                long totalDistance = 0;
                
                for (var k = 0; k <= Math.Min(i, factory[j - 1][1]); k++) {
                    if (k > 0) 
                        totalDistance += Math.Abs(sortedRobots[i - k] - factory[j - 1][0]);
                    
                    dp[i, j] = Math.Min(dp[i, j], dp[i - k, j - 1] + totalDistance);
                }
            }
        }

        return dp[n, m];
    }
}