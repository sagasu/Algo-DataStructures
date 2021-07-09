using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_Increasing_Subsequence
{
    [TestClass]
    public class Longest_Increasing_Subsequence
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {0, 3, 1, 6, 2, 2, 7};
            Assert.AreEqual(4, LengthOfLIS(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 0, 1, 0, 3, 2, 3 };
            Assert.AreEqual(4, LengthOfLIS(t));
        } 
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 7, 7, 7, 7, 7, 7, 7 };
            Assert.AreEqual(1, LengthOfLIS(t));
        }

        /*
         *     0, 3, 1, 6, 2, 2, 7
         * 0,  0  0  0  0  0  0  0
         * 3,  1  0  2  1  2  2  2
         * 1,  2  1  1  1  2  2  2
         * 6,  3  2  2  1  3  3  3
         * 2,  4  2  
         * 2,
         * 7
         *
         *
         *
         */


        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            Array.Fill(dp, 1);
            var max = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j <i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j]+ 1);

                        max = Math.Max(max, dp[i]);
                    }
                }
            }

            return max;
        }
    }
}
