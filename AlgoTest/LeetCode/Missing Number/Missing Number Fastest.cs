using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Missing_Number
{
    [TestClass]
    public class Missing_Number_Fastest
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
            // normally it is (length -1) * length / 2 to calculate sum of all elements from 0
            // but here we know that one of them is missing, so it is extra number potentially the largest one so we do length * (length + 1) / 2
            var expectedSum = (nums.Length * (nums.Length + 1)) / 2;
            foreach (var t in nums)
                actualSum += t;
            

            return expectedSum - actualSum;
        }
    }
}
