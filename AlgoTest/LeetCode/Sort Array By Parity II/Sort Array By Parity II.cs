using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Sort_Array_By_Parity_II
{
    class Sort_Array_By_Parity_II
    {
        public int[] SortArrayByParityII(int[] nums)
        {
            int i = 0, j = 1;
            while (i < nums.Length && j < nums.Length)
            {
                if (i % 2 == 0 && nums[i] % 2 == 0)
                    i += 2;

                else if (j % 2 == 1 && nums[j] % 2 == 1)
                    j += 2;

                else
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i += 2;
                    j += 2;
                }
            }

            return nums;
        }
    }
}
