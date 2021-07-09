using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Maximum_Length_of_Repeated_Subarray
{
    [TestClass]
    public class Maximum_Length_of_Repeated_Subarray
    {
        [TestMethod]
        public void Test()
        {
            var t1 = new int[] {1, 2, 3, 2, 1};
            var t2 = new int[] { 3, 2, 1, 4, 7 };
            Assert.AreEqual(3, FindLength(t1, t2));
        }
        /*
            *   1 2 3 2 1
            * 3 0 0 1 1 1
            * 2 0 0 1 2 1
            * 1 0 0 1 2 3
            * 4
            * 7
            *
            */


        [TestMethod]
        public void Test2()
        {
            var t1 = new int[] { 0, 0, 0, 0, 0 };
            var t2 = new int[] { 0, 0, 0, 0, 0 };
            Assert.AreEqual(5, FindLength(t1, t2));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t1 = new int[] { 1, 0, 0, 0, 1 };
            var t2 = new int[] { 1, 0, 0, 1, 1 };
            Assert.AreEqual(3, FindLength(t1, t2));
        }
        
        
        [TestMethod]
        public void Test4()
        {
            var t1 = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
            var t2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            Assert.AreEqual(9, FindLength(t1, t2));
        }

        /*
         *    0, 0, 0, 0, 0, 0, 1, 0, 0, 0 
         * 0, 1  1  1  1  1  1  0  1  1  1
         * 0, 1  2  2  2  2  2  1  1  2  2
         * 0, 0     3
         * 0,
         * 0,
         * 0,
         * 0,
         * 1,
         * 0,
         * 0 
         *
         *
         */

        public int FindLength(int[] nums1, int[] nums2)
        {
           
            var dp = new int[nums2.Length + 1, nums1.Length + 1];

            var max = 0;

            for (var i = 1; i <= nums2.Length; i++)
            {
                for (var j = 1; j <= nums1.Length; j++)
                {
                    if (nums1[j-1] == nums2[i-1])
                    {
                        dp[i, j] = dp[i-1, j-1] + 1;

                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }

            return max;

        }
    }
}
