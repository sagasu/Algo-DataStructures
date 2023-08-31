using System;

namespace AlgoTest.LeetCode.Minimum_Number_of_Taps_to_Open_to_Water_a_Garden;

public class Minimum_Number_of_Taps_to_Open_to_Water_a_Garden
{
    public int MinTaps(int n, int[] ranges) {
        var dp = new int[ranges.Length + 1];
        Array.Fill(dp, int.MaxValue);
        
        dp[0] = 0;
        
        for (var i = 0; i <= n; i++) {
            var left = Math.Max(0, i - ranges[i]);
            var right = Math.Min(n, i + ranges[i]);
            
            for (var j = left; j <= right; j++)
                if (dp[left] < int.MaxValue)
                    dp[j] = Math.Min(dp[j], dp[left] + 1);
        }
        
        return dp[n] == int.MaxValue ? -1 : dp[n];
    }
}