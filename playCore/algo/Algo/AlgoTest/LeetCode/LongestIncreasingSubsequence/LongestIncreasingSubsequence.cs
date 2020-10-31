using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LongestIncreasingSubsequence
{
    [TestClass]
    public class LongestIncreasingSubsequence
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            Assert.AreEqual(4, LengthOfLIS(t));
        }

        /*
         * j i
         * 3 4 -1 0 6 2 3
         * 1 1  1 1 1 1 1
         *
         * j    i
         * 3 4 -1 0 6 2 3
         * 1 2  1 1 1 1 1
         *
         * j      i
         * 3 4 -1 0 6 2 3
         * 1 2  1 1 1 1 1
         *
         *        j i
         * 3 4 -1 0 6 2 3
         * 1 2  1 2 1 1 1
         *...
         */

        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 1)
                return 1;

            var nrOfLIS = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                nrOfLIS[i] = 1;
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
                        }
                    }
                }

                maxLength = Math.Max(maxLength, nrOfLIS[i]);
            }

            return maxLength;
        }
    }
}
