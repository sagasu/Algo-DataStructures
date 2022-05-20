using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Search_in_Rotated_Sorted_Array
{
    internal class Search_in_Rotated_Sorted_Array
    {
        public int Search(int[] nums, int target)
        {
            var i = 0;
            var j = nums.Length - 1;
            while (i <= j)
            {
                var middle = i + (j - i) / 2;

                if (target == nums[middle])
                    return middle;

                else if (nums[i] < nums[middle] && (target >= nums[i] && target <= nums[middle]))
                    j = middle - 1;
                else if (nums[i] > nums[middle] && (target >= nums[i] || target <= nums[middle]))
                    j = middle - 1;
                else
                    i = middle + 1;
            }

            return -1;
        }
    }
}
