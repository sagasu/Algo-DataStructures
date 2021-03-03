using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Missing_Number
{
    [TestClass]
    public class Missing_Number_Faster
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(1, MissingNumber(new int[]{0}));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, MissingNumber(new int[]{0,1}));
        } 
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(8, MissingNumber(new int[]{ 9, 6, 4, 2, 3, 5, 7, 0, 1 }));
        }


        public int MissingNumber(int[] nums)
        {
            var actualSum = 0;
            var expectedSum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                expectedSum += i;
                actualSum += nums[i];
            }

            return expectedSum + nums.Length - actualSum;
        }
    }
}
