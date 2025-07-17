using System;

namespace AlgoTest.LeetCode.Find_the_Maximum_Length_of_Valid_Subsequence_II;

public class Find_the_Maximum_Length_of_Valid_Subsequence_II
{
    public int MaximumLength(int[] nums, int k) {
        Span<ushort> dp=stackalloc ushort[k*k];
        ushort max=0;
        foreach (var t in nums)
        {
            var si=t % k;
            int di=si * k; 
            int dl=di + k;
            for (; di < dl; si += k, di++) {
                ushort v=dp[di]=(ushort)(dp[si] + 1);
                if(v>max) max=v; 
            }
        }
        return max;
    }
}