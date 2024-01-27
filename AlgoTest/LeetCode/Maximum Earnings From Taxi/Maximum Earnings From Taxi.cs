using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Earnings_From_Taxi;

public class MaximumEarningsFromTaxi
{
    public long MaxTaxiEarnings(int n, int[][] rides) {
        var dp = new long[n + 1];
        var starts = rides
            .GroupBy(x => x[0])
            .ToDictionary(x => x.Key, x => x.ToHashSet());
        
        for (var i = 1; i <= n; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i]);
            
            if (!starts.ContainsKey(i)) {
                continue;
            }
            
            foreach (var ride in starts[i]) {
                var start = i; 
                var end = ride[1];
                var tip = ride[2];
                dp[end] = Math.Max(dp[end], end - start + tip + dp[i]);
            }
        }
        
        return dp[n];
    }
}