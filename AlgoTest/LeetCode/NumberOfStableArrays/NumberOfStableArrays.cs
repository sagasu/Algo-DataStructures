using System;

namespace AlgoTest.LeetCode.NumberOfStableArrays;

public class NumberOfStableArraysSolution
{
    public int NumberOfStableArrays(int zero, int one, int limit) {
        long MOD = 1_000_000_007;
        long[,,] dp = new long[zero + 1, one + 1, 2];
        
        for (int i = 1; i <= Math.Min(zero, limit); i++)
            dp[i, 0, 0] = 1;
        for (int j = 1; j <= Math.Min(one, limit); j++)
            dp[0, j, 1] = 1;
        
        for (int i = 0; i <= zero; i++) {
            for (int j = 0; j <= one; j++) {
                if (i == 0 && j == 0) continue;
                
                if (i > 0 && j > 0)
                    dp[i, j, 0] = (dp[i-1, j, 0] + dp[i-1, j, 1]) % MOD;
                
                if (i > limit && j > 0)
                    dp[i, j, 0] = (dp[i, j, 0] - dp[i-limit-1, j, 1] + MOD) % MOD;
                
                if (j > 0 && i > 0)
                    dp[i, j, 1] = (dp[i, j-1, 0] + dp[i, j-1, 1]) % MOD;
                
                if (j > limit && i > 0)
                    dp[i, j, 1] = (dp[i, j, 1] - dp[i, j-limit-1, 0] + MOD) % MOD;
            }
        }
        
        return (int)((dp[zero, one, 0] + dp[zero, one, 1]) % MOD);
    }
}