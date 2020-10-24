using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._132Pattern
{
    [TestClass]
    public class _132Pattern
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual(false, Find132pattern(t));

            t = new[] { 3,1,4,2};
            Assert.AreEqual(true, Find132pattern(t));

            t = new[] {-1, 3, 2, 0};
            Assert.IsTrue(Find132pattern(t));
        }

        public bool Find132pattern(int[] nums)
        {
            if (nums.Length < 3)
                return false;

            var minMiddle = nums[0];
            for (var i = 1; i < nums.Length-1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > minMiddle && nums[j] < nums[i])
                        return true;
                }
                minMiddle = Math.Min(nums[i], minMiddle);
            }

            return false;
        }
    }
}
