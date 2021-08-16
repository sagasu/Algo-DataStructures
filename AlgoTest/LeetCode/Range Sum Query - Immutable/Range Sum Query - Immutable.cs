using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Range_Sum_Query___Immutable
{
    public class NumArray
    {
        int[] nums;

        public NumArray(int[] nums)
        {
            for (var i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];

            this.nums = nums;
        }

        public int SumRange(int left, int right)
        {
            if (left == 0)
                return nums[right];

            return nums[right] - nums[left - 1];
        }
    }
}
