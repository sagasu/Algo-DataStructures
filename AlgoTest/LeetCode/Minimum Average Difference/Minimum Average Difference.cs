using System;

public class MinimumAverageDifferenceSolution {
    public int MinimumAverageDifference(int[] nums) {
                if (nums.Length == 1) return 0;

        long leftSum = 0;
        long rightSum = 0;

        foreach (var num in nums)
        {
            rightSum += num;
        }

        long minDiff = long.MaxValue;
        int result = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];

            var diff = Math.Abs(leftSum / (i + 1) - (rightSum / Math.Max(nums.Length - i - 1, 1)));

            if (diff < minDiff)
            {
                minDiff = diff;
                result = i;
            }

        }

        return result;
    }
}