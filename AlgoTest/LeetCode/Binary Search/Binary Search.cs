using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Binary_Search
{
    internal class Binary_Search
    {
        public int Search(int[] nums, int target)
        {
            var i = 0;
            var j = nums.Length - 1;
            while (i <= j)
            {
                var mid = i + (j - i) / 2;
                if (nums[mid] < target) i = mid + 1;
                else if (nums[mid] > target) j = mid - 1;
                else return mid;
            }
            return -1;
        }
    }
}
