using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Search_in_Rotated_Sorted_Array_II
{
    internal class Search_in_Rotated_Sorted_Array_II
    {
        public bool Search(int[] nums, int target)
        {
            var i = nums.Length - 1;
            for (; i >= 0; i--)
            {
                if (nums[i] == target) return true;
                if (nums[i] < target) break;
            }

            for (var j = 0; j < i; j++)
            {
                if (nums[j] == target) return true;
                if (nums[j] > target) return false;
            }

            return false;
        }
    }
}
