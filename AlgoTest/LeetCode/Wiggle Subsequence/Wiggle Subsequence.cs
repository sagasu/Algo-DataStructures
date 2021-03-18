using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Wiggle_Subsequence
{
    public class Wiggle_Subsequence
    {
        public int WiggleMaxLength(int[] nums)
        {
            int FindIncreasing(int index)
            {
                if (index == nums.Length) return 0;

                if (index == 0)
                    return 1 + FindIncreasing(index + 1);

                if (nums[index] >= nums[index - 1])
                    return FindIncreasing(index + 1);
                
                return 1 + FindDecreasing(index + 1);
            }

            int FindDecreasing(int index)
            {
                if (index == nums.Length) return 0;

                if (index == 0) return 1 + FindDecreasing(index + 1);

                if (nums[index] <= nums[index - 1]) return FindDecreasing(index + 1);

                return 1 + FindIncreasing(index + 1);
            }

            return Math.Max(FindIncreasing(0), FindDecreasing(0));
        }
    }
}
