using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Search_Insert_Position
{
    public  class Search_Insert_Position
    {
        public int SearchInsert(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;

            if (target >= nums[^1]) return nums.Length;

            while (low < high)
            {
                var mid = (low + high) / 2;

                if (target > nums[mid]) low = mid + 1;
                else high = mid;
            }
            return low;
        }
    }
}
