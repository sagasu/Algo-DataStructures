using System;

namespace AlgoTest.LeetCode.Number_of_People_Aware_of_a_Secret;

public class Number_of_People_Aware_of_a_Secret
{
    public int PeopleAwareOfSecret(int n, int delay, int forget) {
        const int MOD = 1_000_000_007;
        if (n == 1) return 1;

        long[] dp = new long[n + 1]; 
        dp[1] = 1;
        long windowSum = 0; 

        for (int i = 2; i <= n; i++) {
            int enterIdx = i - delay; 
            int exitIdx  = i - forget; 

            if (enterIdx >= 1) {
                windowSum = (windowSum + dp[enterIdx]) % MOD;
            }
            if (exitIdx >= 1) {
                windowSum = (windowSum - dp[exitIdx] + MOD) % MOD;
            }

            dp[i] = windowSum;
        }

        long result = 0;
        int start = Math.Max(1, n - forget + 1);
        for (int i = start; i <= n; i++) {
            result = (result + dp[i]) % MOD;
        }

        return (int)result;
    }
}