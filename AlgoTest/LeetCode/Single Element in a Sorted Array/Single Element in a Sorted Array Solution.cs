using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Single_Element_in_a_Sorted_Array
{
    public class Single_Element_in_a_Sorted_Array_Solution
    {
        public int SingleNonDuplicate(int[] nums)
        {
            var left = 0;
            var right = nums.Length/2;

            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid*2] == nums[mid *2 + 1]) left = mid + 1;
                else right = mid;
            }
            return nums[left*2];
        }
    }
}
