using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Missing_Number
{
    [TestClass]
    public class Missing_Number
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
            var elements = new int[nums.Length+1];
            for (var i = 0; i < nums.Length; i++)
            {
                elements[nums[i]] = 1;
            }

            for (var i = 0; i < elements.Length; i++)
            {
                if (elements[i] == 0) return i;
            }

            return 0;
        }
    }
}
