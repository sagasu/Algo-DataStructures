using System;

namespace AlgoTest.LeetCode.Longest_Strictly_Increasing_or_Strictly_Decreasing_Subarray;

public class Longest_Strictly_Increasing_or_Strictly_Decreasing_Subarray
{
    public int LongestMonotonicSubarray(int[] nums) {
        if (nums.Length == 1) 
            return 1;

        var maxStreak = 1;
        var previousCompareToValue = nums[0].CompareTo(nums[1]);
        var currentStreak = (previousCompareToValue == 0) ? 1 : 2;

        for (int i = 1; i < nums.Length - 1; ++i) {
            var currentCompareToValue = nums[i].CompareTo(nums[i + 1]);

            if (currentCompareToValue != 0 && 
                (previousCompareToValue == 0 || previousCompareToValue == currentCompareToValue)) {
                currentStreak++;
            } else {
                maxStreak = Math.Max(maxStreak, currentStreak);
                currentStreak = (currentCompareToValue == 0) ? 1 : 2;
            }
 
            previousCompareToValue = currentCompareToValue;
        }

        return Math.Max(maxStreak, currentStreak);
    }
}