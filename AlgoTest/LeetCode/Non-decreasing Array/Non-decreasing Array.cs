using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Non_decreasing_Array
{
    [TestClass]
    public class Non_decreasing_Array
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, CheckPossibility(new int[] {4, 2, 3}));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(false, CheckPossibility(new int[] {4, 2, 1}));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(false, CheckPossibility(new int[] {3,4,2,3}));
        }
        
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(true, CheckPossibility(new int[] {5,7,1,8}));
        }
        
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(true, CheckPossibility(new int[] {1,2,4,5,3}));
        }

        public bool CheckPossibility(int[] nums)
        {
            var count = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    count += 1;
                    if (i - 2 >= 0 && nums[i - 2] > nums[i])
                    {
                        if(i + 1 == nums.Length || (i + 1 < nums.Length && nums[i+1] > nums[i-1])) continue;
                        return false;
                    }
                }
            }

            return count <= 1;
        }
    }
}
