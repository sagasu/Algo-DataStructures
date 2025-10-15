using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Adjacent_Increasing_Subarrays_Detection_II;

public class Adjacent_Increasing_Subarrays_Detection_II
{
    public int MaxIncreasingSubarrays(IList<int> nums) {
        int n = nums.Count;
        int up = 1, preUp = 0, res = 0;
        for (int i = 1; i < n; i++) {
            if (nums[i] > nums[i - 1]) up++;
            else {
                preUp = up;
                up = 1;
            }
            int half = up >> 1;
            int m = Math.Min(preUp, up);
            int candidate = Math.Max(half, m);
            if (candidate > res) res = candidate;
        }
        return res;
    }
}