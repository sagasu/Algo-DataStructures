using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.House_Robber
{
    class House_Robber
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            
            var firstPrevious = 0;
            var current = 0;

            foreach (var num in nums) {
                var secondPrevious = firstPrevious;
                firstPrevious = current;
                current = Math.Max(firstPrevious, secondPrevious + num);
            }

            return current;
        }
    }
}
