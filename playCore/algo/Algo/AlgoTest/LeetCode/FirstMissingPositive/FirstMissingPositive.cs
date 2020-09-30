using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FirstMissingPositive
{
    class FirstMissingPositiveSolution
    {
        public int FirstMissingPositive(int[] nums)
        {
            for(var i = 0; i < nums.Length; i++)
                while (nums[i] > 0 && nums[i] < nums.Length && nums[nums[i] - 1] != nums[i])
                    Swap(i, nums[i] - 1);

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    return i + 1;
            }

            return nums.Length + 1;

            void Swap(int a, int b)
            {
                var temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
            }
        }

        
    }
}
