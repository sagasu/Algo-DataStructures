using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.MaximumSubarray
{
    public class MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            var previous = nums[0];
            var max = previous;

            for (var i = 1; i < nums.Length; i++) {
                var current = Math.Max(nums[i], previous + nums[i]);
                if (current > max)
                    max = current;
                previous = current;
            }

            return max;
        }
    }
}
