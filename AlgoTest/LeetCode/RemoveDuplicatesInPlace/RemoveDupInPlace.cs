using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.RemoveDuplicatesInPlace
{
    [TestClass]
    public class RemoveDupInPlace
    {
        [TestMethod]
        public void Test()
        {
            //var nums = new[] {1, 1, 2};
            var nums = new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            RemoveDuplicates(nums);
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;

            var current = nums[0];
            var nextIndex = 0;
            var length = 1;
            var replace = false;
            for (var i = 1; i < nums.Length; i++)
            {
                if (current == nums[i])
                {
                    if(!replace)
                        nextIndex = i;

                    replace = true;
                }else if (replace)
                {
                    current = nums[i];
                    nums[nextIndex] = nums[i];
                    nextIndex += 1;
                    length += 1;
                }
                else
                {
                    current = nums[i];
                    length += 1;
                }
            }

            return length;
        }
    }
}
