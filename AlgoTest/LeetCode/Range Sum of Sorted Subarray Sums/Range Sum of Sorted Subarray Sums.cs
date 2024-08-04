using System.Collections.Generic;

namespace AlgoTest.LeetCode.Range_Sum_of_Sorted_Subarray_Sums;

public class Range_Sum_of_Sorted_Subarray_Sums
{
    public int RangeSum(int[] nums, int n, int left, int right)
    {
        long ans = 0;
        var subarraySum = new List<int>();

        for(var i = 1; i < nums.Length; i++)
            nums[i] += nums[i - 1];

        for(var i = 0; i < nums.Length; i++)
        {
            subarraySum.Add(nums[i]);

            for(int j = i + 1; j < nums.Length; j++)
                subarraySum.Add(nums[j] - nums[i]);
        }

        subarraySum.Sort();

        for (int i = left - 1; i < right; i++)
            ans = (ans + subarraySum[i]) % 1000000007;

        return (int)ans;
    }
}