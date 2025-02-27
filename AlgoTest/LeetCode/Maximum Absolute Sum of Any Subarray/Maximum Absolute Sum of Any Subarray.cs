using System;

namespace AlgoTest.LeetCode.beat_down_the_temperature;

public class MaximumAbsoluteSumofAnySubarray
{
    public int MaxAbsoluteSum(int[] nums) {

        var maxSoFar = nums[0];
        var maxEndingHere = nums[0];
        var minSoFar = nums[0];
        var minEndingHere = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);

            minEndingHere = Math.Min(nums[i], minEndingHere + nums[i]);
            minSoFar = Math.Min(minSoFar, minEndingHere);
        }

        return Math.Abs(minSoFar) > maxSoFar ? Math.Abs(minSoFar) : maxSoFar;
    }
}