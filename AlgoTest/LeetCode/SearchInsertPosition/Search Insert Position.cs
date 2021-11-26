using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SearchInsertPosition
{
    class Search_Insert_Position
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums[nums.Length - 1] < target) return nums.Length;

            var low = 0;
            var hight = nums.Length - 1;

            while (low < hight) {
                var mid = (hight + low) / 2;

                if (target > nums[mid]) low = mid + 1;
                else hight = mid;
            }

            return low;
        }
    }
}

