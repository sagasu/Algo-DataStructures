using System;
using System.Numerics;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_Array_Elements_Zero;

public class Minimum_Operations_to_Make_Array_Elements_Zero
{
    public long MinOperations(int[][] queries) {
        long ans = 0;
        foreach (var q in queries) {
            int l = q[0], r = q[1];
            long S = 0; 
            int dMax = 0; 

            for (int k = 1; k <= 31; k++) {
                long low = 1L << (k - 1);
                long high = (1L << k) - 1;
                if (low > r) break; 
                long a = Math.Max((long)l, low);
                long b = Math.Min((long)r, high);
                if (a > b) continue;
                long cnt = b - a + 1;
                int stepsForK = (k + 1) / 2;
                S += cnt * stepsForK;
                if (stepsForK > dMax) dMax = stepsForK;
            }

            long ops = Math.Max((long)dMax, (S + 1) / 2); 
            ans += ops;
        }
        return ans;
    }

    private int Div4Steps(int a) {
        if (a <= 0) return 0;
        int bitLength = 32 - BitOperations.LeadingZeroCount((uint)a);
        return (bitLength + 1) / 2;
    }
}