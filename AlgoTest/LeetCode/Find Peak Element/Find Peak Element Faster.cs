using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_Peak_Element
{
    [TestClass]
    public class Find_Peak_Element_Faster
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 2, 3, 1};
            Assert.AreEqual(2, FindPeakElement(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 1, 2, 1, 3, 5, 6, 4 };
            Assert.AreEqual(1, FindPeakElement(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] {1,2 };
            Assert.AreEqual(1, FindPeakElement(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {1,2,3 };
            Assert.AreEqual(2, FindPeakElement(t));
        }

        public int FindPeakElement(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] > nums[mid + 1])
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
