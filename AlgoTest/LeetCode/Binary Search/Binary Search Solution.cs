using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Binary_Search
{
    internal class Binary_Search_Solution
    {
        public int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] < target) left = mid + 1;
                else if (nums[mid] > target) right = mid - 1;
                else return mid;
            }
            return -1;
        }
    }
}
