using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.RotateArray
{
    class RotateArray
    {
        //Right
        public void Rotate(int[] nums, int k)
        {
            var rotatedArray = new int[nums.Length];
            Array.Copy(nums, rotatedArray, nums.Length);

            var index = 0;
            while (index < nums.Length)
            {
                var nextPosition = (index + k) % nums.Length;
                nums[nextPosition] = rotatedArray[index];
                index += 1;
            }
        }
    }
}
