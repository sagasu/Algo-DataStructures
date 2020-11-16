using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LongestMountainInArray
{
    [TestClass]
    public class LongestMountainInArray
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 4, 7, 3, 2 };
            Assert.AreEqual(5, LongestMountain(t));

            t = new int[] { 2, 1, 4, 7, 3, 2, 5 };
            Assert.AreEqual(5, LongestMountain(t));

            t = new int[] { 2, 2, 2 };
            Assert.AreEqual(0, LongestMountain(t));
            
            t = new int[] { 0,1,0};
            Assert.AreEqual(3, LongestMountain(t)); 
            
            t = new int[] { 0,1,0,1};
            Assert.AreEqual(3, LongestMountain(t));
            
            t = new int[] {0, 1, 0, 2, 2};
            Assert.AreEqual(3, LongestMountain(t));
        }

        public int LongestMountain(int[] A)
        {
            if (A.Length < 3)
                return 0;

            var maxMountainLength = 0;
            var currentLength = 1;
            var isLeftSlope = true;
            for (var i = 1; i < A.Length - 1; i++)
            {
                if (isLeftSlope)
                {
                    if (currentLength != 1 && A[i - 1] > A[i])
                    {
                        isLeftSlope = false;
                        currentLength += 1;
                    } else if(A[i - 1] < A[i])
                        currentLength += 1;
                }
                else
                {
                    currentLength += 1;
                    if (A[i] < A[i+1])
                    {
                        isLeftSlope = true;
                        maxMountainLength = Math.Max(maxMountainLength, currentLength);
                        currentLength = 1;

                    }
                }
            }

            var addOne = !isLeftSlope && A[A.Length - 2] <= A[A.Length - 1] ? 0 : 1;

            if (!isLeftSlope || (A[A.Length - 2] > A[A.Length-1] && currentLength != 1) )
                maxMountainLength = Math.Max(maxMountainLength, currentLength + addOne);

            return maxMountainLength;
        }
    }
}
