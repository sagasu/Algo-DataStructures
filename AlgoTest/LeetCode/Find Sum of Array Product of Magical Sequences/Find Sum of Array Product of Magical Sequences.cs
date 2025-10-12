namespace AlgoTest.LeetCode.Find_Sum_of_Array_Product_of_Magical_Sequences;

public class Find_Sum_of_Array_Product_of_Magical_Sequences
{
    const int MOD = 1_000_000_007;

    public int MagicalSum(int m, int k, int[] nums) {
        int n = nums.Length;

        long[][] powtab = new long[n][];
        for (int i = 0; i < n; i++) {
            powtab[i] = new long[m + 1];
            powtab[i][0] = 1;
            for (int c = 1; c <= m; c++) {
                powtab[i][c] = (powtab[i][c - 1] * nums[i]) % MOD;
            }
        }

        long[][] comb = new long[m + 1][];
        for (int i = 0; i <= m; i++) {
            comb[i] = new long[m + 1];
            comb[i][0] = 1;
            for (int j = 1; j <= i; j++) {
                comb[i][j] = (comb[i - 1][j - 1] + comb[i - 1][j]) % MOD;
            }
        }

        long[,,] dp = new long[m + 1, m + 1, k + 1];
        dp[m, 0, 0] = 1;

        for (int i = 0; i < n; i++) {
            long[,,] next = new long[m + 1, m + 1, k + 1];
            long[] powi = powtab[i];

            for (int rem = 0; rem <= m; rem++) {
                for (int carry = 0; carry <= m; carry++) {
                    for (int ones = 0; ones <= k; ones++) {
                        long baseVal = dp[rem, carry, ones];
                        if (baseVal == 0) continue;

                        for (int c = 0; c <= rem; c++) {
                            int t = c + carry;
                            int bit = t & 1;
                            int ones2 = ones + bit;
                            if (ones2 > k) continue;

                            int carry2 = t >> 1;
                            int rem2 = rem - c;

                            long add = baseVal;
                            add = (add * comb[rem][c]) % MOD;
                            add = (add * powi[c]) % MOD;

                            next[rem2, carry2, ones2] = (next[rem2, carry2, ones2] + add) % MOD;
                        }
                    }
                }
            }

            dp = next;
        }

        long total = 0;
        for (int carry = 0; carry <= m; carry++) {
            int extra = PopCount(carry);
            int need = k - extra;
            if (need >= 0 && need <= k) {
                total = (total + dp[0, carry, need]) % MOD;
            }
        }

        return (int)total;
    }

    private int PopCount(int x) {
        int cnt = 0;
        while (x != 0) {
            x &= (x - 1);
            cnt++;
        }
        return cnt;
    }
}