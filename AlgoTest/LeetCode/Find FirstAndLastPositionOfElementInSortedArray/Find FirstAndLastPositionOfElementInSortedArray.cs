using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Find_FirstAndLastPositionOfElementInSortedArray
{
    class Find_FirstAndLastPositionOfElementInSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var startIndex = FindStartIndex(nums, target);
            var endIndex = FindEndIndex(nums, target);
            return new int[]{startIndex,endIndex};
        }

        public int FindStartIndex(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;
            var startIndex = -1;
            while (start <= end)
            {
                var index = start + (end - start) / 2;
                if (nums[index] >= target)
                {
                    end = index - 1;
                }
                else
                {
                    start = index + 1;
                }

                if (nums[index] == target)
                    startIndex = index;
            }

            return startIndex;
        }

        public int FindEndIndex(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;
            var startIndex = -1;
            while (start <= end)
            {
                var index = start + (end - start) / 2;
                if (nums[index] <= target)
                {
                    start = index + 1;
                }
                else
                {
                    end = index -1;
                }

                if (nums[index] == target)
                    startIndex = index;
            }

            return startIndex;
        }
    }
}
