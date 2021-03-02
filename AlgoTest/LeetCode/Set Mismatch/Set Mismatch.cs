using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Set_Mismatch
{
    [TestClass]
    public class Set_Mismatch
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
        //n + nlogn
        public int[] FindErrorNums(int[] nums)
        {
            Array.Sort(nums);
            var dupIndex = 0;
            var missingNumber = nums[0] == 1 ? nums.Length: 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) dupIndex = i;
                else if (nums[i] != nums[i - 1] + 1) missingNumber = nums[i-1] + 1;
            }

            return new[] { nums[dupIndex], missingNumber };
        }
    }
}
