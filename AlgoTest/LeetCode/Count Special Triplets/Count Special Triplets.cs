using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Special_Triplets;

public class Count_Special_Triplets
{
    public int SpecialTriplets(int[] nums) {
        const int MOD = 1_000_000_007;
        var left = new Dictionary<int, long>();
        var right = new Dictionary<int, long>();

        foreach (int x in nums) {
            if (!right.ContainsKey(x)) right[x] = 0;
            right[x]++;
        }

        long ans = 0;

        foreach (int x in nums) {
            right[x]--;

            int need = x * 2;
            long lc = left.ContainsKey(need) ? left[need] : 0;
            long rc = right.ContainsKey(need) ? right[need] : 0;

            ans = (ans + lc * rc) % MOD;

            if (!left.ContainsKey(x)) left[x] = 0;
            left[x]++;
        }

        return (int)ans;
    }
}