using System;

namespace AlgoTest.LeetCode.Ways_to_Express_an_Integer_as_Sum_of_Powers;

public class Ways_to_Express_an_Integer_as_Sum_of_Powers
{
    public int NumberOfWays(int n, int x) {
        int[] table = new int[(int) Math.Ceiling(Math.Pow(n, 1.0/x)) + 1];
        for (int i = 1; i < table.Length; i++) {
            table[i] = (int) Math.Pow(i, x);
        }

        int[] dp = new int[n + 1];
        for (int i = 1; i < table.Length && table[i] <= n; i++) {
            for (int j = n - table[i]; j > 0; j--) {
                if (dp[j] == 0) continue;
                dp[j + table[i]] = (dp[j + table[i]] + dp[j]) % 1_000_000_007;
            }
            dp[table[i]]++;
        }
        return dp[n];
    }
}