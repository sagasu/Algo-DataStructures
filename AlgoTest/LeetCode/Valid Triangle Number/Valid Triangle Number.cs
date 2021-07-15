using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Valid_Triangle_Number
{
    [TestClass]
    public class Valid_Triangle_Number
    {
        [TestMethod]
        public void Test()
        {
            var t = new[] {2, 2, 3, 4};
            Assert.AreEqual(3, TriangleNumber(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new[] { 4, 2, 3, 4 };
            Assert.AreEqual(4, TriangleNumber(t));
        }

        public int TriangleNumber(int[] nums)
        {
            if (nums == null || nums.Length < 3) return 0;

            var count = 0;
            Array.Sort(nums);

            //i is the longest side, left and right are the short sides.
            for (var i = nums.Length - 1; i >= 2; i--)
            {
                var left = 0;
                var right = i - 1;
                while (left < right)
                {
                    if (nums[left] + nums[right] > nums[i])
                    {
                        count += right - left;
                        right -= 1;
                    } else left += 1;
                }
            }

            return count;
        }
    }
}
