using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Set_Mismatch
{
    [TestClass]
    public class Set_Mismatch_Faster
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(new int[]{ 2, 3 }, FindErrorNums(new int[]{ 1, 2, 2, 4 }));
        }
        
        [TestMethod]
        public void Test2()
        {
            CollectionAssert.AreEqual(new int[]{ 4, 5 }, FindErrorNums(new int[]{ 1, 2, 3, 4, 4 }));
        }
        
        [TestMethod]
        public void Test3()
        {
            CollectionAssert.AreEqual(new int[]{ 1, 2 }, FindErrorNums(new int[]{ 1, 1 }));
        }
        
        [TestMethod]
        public void Test4()
        {
            CollectionAssert.AreEqual(new int[]{ 2, 5 }, FindErrorNums(new int[]{ 1, 2, 2, 3, 4, 6 }));
        }
        
        [TestMethod]
        public void Test5()
        {
            CollectionAssert.AreEqual(new int[]{ 2, 1 }, FindErrorNums(new int[]{ 3, 2, 2 }));
        }

        // 2N
        public int[] FindErrorNums(int[] nums)
        {
            var dupIndex = 0;
            var missingNumber = 1;
            var count = new int[nums.Length+1];

            for (var i = 0; i < nums.Length; i++)
                count[nums[i]] += 1;

            for (var i = 1; i < count.Length; i++)
            {
                if (count[i] == 2) dupIndex = i;
                if (count[i] == 0) missingNumber = i;
            }

            return new[] { nums[dupIndex], missingNumber };
        }
    }
}
