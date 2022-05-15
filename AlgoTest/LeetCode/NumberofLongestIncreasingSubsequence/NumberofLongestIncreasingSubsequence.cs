using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.NumberofLongestIncreasingSubsequence
{
    [TestClass]
    public class NumberofLongestIncreasingSubsequence
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 3, 5, 4, 7 };
            Assert.AreEqual(2, FindNumberOfLIS(t));

            t = new int[] { 2, 2, 2, 2, 2};
            Assert.AreEqual(5, FindNumberOfLIS(t));
            
            t = new int[] { 1, 2, 4, 3, 5, 4, 7, 2};
            Assert.AreEqual(3, FindNumberOfLIS(t));
        }

        public int FindNumberOfLIS(int[] nums)
        {
            if (nums.Length == 1) return 1;

            var nrOfLIS = new int[nums.Length];
            var count = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                nrOfLIS[i] = 1;
                count[i] = 1;
            }

            var maxLength = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (nrOfLIS[j] + 1 > nrOfLIS[i])
                        {
                            nrOfLIS[i] = nrOfLIS[j] + 1;
                            count[i] = count[j];
                        }
                        else if (nrOfLIS[j] + 1 == nrOfLIS[i]) count[i] += count[j];
                    }
                }

                maxLength = Math.Max(maxLength, nrOfLIS[i]);
            }

            var maxCount = 0;
            for (var i = 0; i < nums.Length; i++)
                if (nrOfLIS[i] == maxLength) maxCount += count[i];
            

            return maxCount;
        }
    }
}
