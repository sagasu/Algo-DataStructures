using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Maximum_Length_of_Repeated_Subarray
{
    [TestClass]
    public class Maximum_Length_of_Repeated_Subarray_DifferentSolution
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

        public int FindLength(int[] nums1, int[] nums2)
        {

            var max = 0;
            var matrix = new int[nums1.Length + 1, nums2.Length + 1];

            for (var i = 0; i < nums1.Length; i++)
            for (var j = 0; j < nums2.Length; j++)
                if (nums1[i] == nums2[j])
                {
                    matrix[i + 1, j + 1] = matrix[i, j] + 1;
                    if (matrix[i + 1, j + 1] > max) max = matrix[i + 1, j + 1];
                }

            return max;

        }
    }
}
