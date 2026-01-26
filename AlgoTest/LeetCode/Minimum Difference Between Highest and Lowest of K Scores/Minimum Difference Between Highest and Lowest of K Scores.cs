using System;

namespace AlgoTest.LeetCode.Minimum_Difference_Between_Highest_and_Lowest_of_K_Scores;

public class Minimum_Difference_Between_Highest_and_Lowest_of_K_Scores
{
    public int MinimumDifference(int[] nums, int k) {
        if (k == 1) return 0;

        Array.Sort(nums);
        int minDiff = int.MaxValue;

        for (int i = 0; i <= nums.Length - k; i++) {
            minDiff = Math.Min(minDiff, nums[i + k - 1] - nums[i]);
        }

        return minDiff;
    }
}