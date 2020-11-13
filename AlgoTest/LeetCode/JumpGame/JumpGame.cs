using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.JumpGame
{
    [TestClass]
    public class JumpGame
    {
        [TestMethod]
        public void Test()
        {
            //var t = new int[] {2, 3, 1, 1, 4};
            //var t = new int[] { 3, 2, 1, 0, 4 };
            //var t = new int[] { 2,0};
            var t = new int[] { 2, 5, 0, 0};
            Assert.AreEqual(true, CanJump(t));
        }

        public bool CanJump(int[] nums)
        {
            return CanJump(nums, 0);
        }

        public bool CanJump(int[] nums, int index)
        {
            if (index == nums.Length-1)
                return true;

            if (index >= nums.Length)
                return false;

            for (var i = nums[index]; i > 0; i--)
            {
                if (i > nums.Length)
                    continue;

                if (CanJump(nums, index + i))
                    return true;
            }

            return false;
        }
    }
}
