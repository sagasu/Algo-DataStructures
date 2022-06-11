using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Reduce_X_to_Zero
{
    internal class Minimum_Operations_to_Reduce_X_to_Zero
    {
        public int MinOperations(int[] nums, int x)
        {
            var target = nums.Sum() - x;

            var maximumLengthOfMiddle = int.MinValue;
            var sum = 0;
            var left = 0;
            for (var right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (left <= right && target < sum)
                {
                    sum -= nums[left];
                    left++;
                }

                if (sum == target) maximumLengthOfMiddle = Math.Max(maximumLengthOfMiddle, right - left + 1);
            }

            return maximumLengthOfMiddle == int.MinValue ? -1 : nums.Length - maximumLengthOfMiddle;
        }
    }
}
