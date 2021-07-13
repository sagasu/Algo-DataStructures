using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_Peak_Element
{
    [TestClass]
    public class Find_Peak_Element
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
            if (nums.Length == 1) return 0;
            for (var i = 1; i < nums.Length-1; i++)
            {
                if (nums[i - 1] < nums[i] && nums[i] > nums[i + 1]) return i;
            }

            return nums[nums.Length-2] < nums[nums.Length-1] ? nums.Length - 1 : 0;
        }
    }
}
