using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LongestIncreasingSubsequence
{
    [TestClass]
    public class LongestIncreasingSubsequenceSolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            Assert.AreEqual(4, LengthOfLIS(t));
        }
        
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 1)
                return 1;

            var dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (var i = 1; i < nums.Length; i++)
                for (var j = 0; j < i; j++)
                    if (nums[i] > nums[j]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            
            return dp.Max();
        }
    }
}
