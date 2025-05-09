using System;

namespace AlgoTest.LeetCode.Count_Number_of_Balanced_Permutations;

public class Count_Number_of_Balanced_Permutations
{
    private const long MOD = 1_000_000_007;
    private long[,,] memo;
    private int[] cnt;
    private int[] psum;
    private int target;
    private long[,] comb;

    public int CountBalancedPermutations(string num) {
        int tot = 0, n = num.Length;
        cnt = new int[10];
        foreach (char ch in num) {
            int d = ch - '0';
            cnt[d]++;
            tot += d;
        }
        if (tot % 2 != 0) {
            return 0;
        }

        target = tot / 2;
        int maxOdd = (n + 1) / 2;
        comb = new long[maxOdd + 1, maxOdd + 1];
        for (int i = 0; i <= maxOdd; i++) {
            comb[i, i] = comb[i, 0] = 1;
            for (int j = 1; j < i; j++) {
                comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % MOD;
            }
        }

        psum = new int[11];
        for (int i = 9; i >= 0; i--) {
            psum[i] = psum[i + 1] + cnt[i];
        }

        memo = new long[10, target + 1, maxOdd + 1];
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j <= target; j++) {
                for (int k = 0; k <= maxOdd; k++) {
                    memo[i, j, k] = -1;
                }
            }
        }

        return (int)Dfs(0, 0, maxOdd);
    }

    private long Dfs(int pos, int curr, int oddCnt) {
        if (oddCnt < 0 || psum[pos] < oddCnt || curr > target) {
            return 0;
        }
        if (pos > 9) {
            return (curr == target && oddCnt == 0) ? 1 : 0;
        }
        if (memo[pos, curr, oddCnt] != -1) {
            return memo[pos, curr, oddCnt];
        }
        int evenCnt = psum[pos] - oddCnt;
        long res = 0;
        for (int i = Math.Max(0, cnt[pos] - evenCnt);
             i <= Math.Min(cnt[pos], oddCnt); i++) {
            long ways = comb[oddCnt, i] * comb[evenCnt, cnt[pos] - i] % MOD;
            res =
                (res + ways * Dfs(pos + 1, curr + i * pos, oddCnt - i) % MOD) %
                MOD;
        }
        memo[pos, curr, oddCnt] = res;
        return res;
    }
}