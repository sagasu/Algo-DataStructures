using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

public class Maximum_Sum_of_Distinct_Subarrays_With_Length_K
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long maximumSubarraySum = 0;
        var prefixSum = new long[nums.Length + 1];
        var pos = new int[nums.Max() + 1];

        for (int i = 0, j = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];

            if (pos[nums[i]] != 0)
            {
                while (j < pos[nums[i]])
                    pos[nums[j++]] = 0;
            }

            if (i - j + 1 > k)
                pos[nums[j++]] = 0;

            if (i - j + 1 == k)
                maximumSubarraySum = Math.Max(maximumSubarraySum, prefixSum[i + 1] - prefixSum[j]);

            pos[nums[i]] = i + 1;
        }

        return maximumSubarraySum;
    }
}