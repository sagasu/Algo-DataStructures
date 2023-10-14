using System;

namespace AlgoTest.LeetCode.Painting_the_Walls;

public class Painting_the_Walls
{
    private long[,] dp;

    public int PaintWalls(int[] cost, int[] time) {
        var n = cost.Length;
        dp = new long[n + 1, n + 1];
        
        for (var i = 0; i <= n; i++) 
            for (var j = 0; j <= n; j++) 
                dp[i, j] = -1;
        
        var res = F(cost, time, 0, 0);
        return (int) res;
    }

    private long F(int[] cost, int[] time, int i, int t) {
        if (t >= cost.Length)
            return 0;
        
        if (i == cost.Length)
            return int.MaxValue;
        
        if (dp[i, t] != -1)
            return dp[i, t];
        
        dp[i, t] = Math.Min(cost[i] + F(cost, time, i + 1, t + 1 + time[i]), F(cost, time, i + 1, t));
        return dp[i, t];
    }
}