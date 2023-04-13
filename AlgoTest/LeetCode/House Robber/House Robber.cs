using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.House_Robber
{
    [TestClass]
    public class House_Robber
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(4, Rob(new int[] { 1, 2, 3, 1 }));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual(12, Rob(new int[] { 2, 7, 9, 3, 1 }));
        
        [TestMethod]
        public void Test3() => Assert.AreEqual(12, Rob(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17}));

        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            
            var firstPrevious = 0;
            var current = 0;

            foreach (var num in nums) {
                // both of them below do not just store a previous value, they store a max sum till previous and one before position
                var secondPrevious = firstPrevious; // stores max sum till second previous
                firstPrevious = current; // stores max sum till first previous
                current = Math.Max(firstPrevious, secondPrevious + num);
            }

            return current;
        }
    }
}
