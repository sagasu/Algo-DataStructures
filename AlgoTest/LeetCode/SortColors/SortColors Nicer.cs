﻿using System;

namespace AlgoTest.LeetCode.SortColors
{
    class SortColorsProblem_Nicer
    {
        public void SortColors(int[] nums)
        {
            var copy = new int[nums.Length]; 
            Array.Copy(nums, copy, nums.Length);

            var startIndex = 0;
            var endIndex = nums.Length - 1;

            for (var i = 0; i < nums.Length; i++)
                if (copy[i] == 0)
                {
                    nums[startIndex] = 0;
                    startIndex += 1;
                }
                else if (copy[i] == 2)
                {
                    nums[endIndex] = 2;
                    endIndex -= 1;
                }
            

            for (var i = startIndex; i <= endIndex; i++) nums[i] = 1;
        }
    }
}
