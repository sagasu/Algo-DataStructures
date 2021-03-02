using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Set_Mismatch
{
    [TestClass]
    public class Set_Mismatch_No_Sort
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

        // Solution with a faster runtime, because we don't sort. 3N
        public int[] FindErrorNums(int[] nums)
        {
            var dic = new Dictionary<int,int>();
            for (var i = 1; i < nums.Length+1; i++)
            {
                dic.Add(i, 0);
            }
            var dupIndex = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (dic[nums[i]] == 1) dupIndex = i;
                dic[nums[i]] = 1;
            }

            var missing = dic.Keys.First(x => dic[x] == 0);

            return new[] { nums[dupIndex], missing };
        }
    }
}
