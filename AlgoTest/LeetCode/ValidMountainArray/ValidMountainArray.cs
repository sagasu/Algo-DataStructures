using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ValidMountainArray
{
    [TestClass]
    public class ValidMountainArraySolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {2, 1};
            Assert.IsFalse(ValidMountainArray(t));
        }

        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 3, 5, 5 };
            Assert.IsFalse(ValidMountainArray(t));
        }

        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 0, 3, 2, 1 };
            Assert.IsTrue(ValidMountainArray(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] { 1,3,2 };
            Assert.IsTrue(ValidMountainArray(t));
        }
        
        [TestMethod]
        public void Test5()
        {
            var t = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Assert.IsFalse(ValidMountainArray(t));
        }

        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3) return false;

            bool isRaising = true;
            for (var i = 1; i < arr.Length; i++)
            {
                if (isRaising)
                {
                    if (arr[i - 1] == arr[i]) return false;

                    if (arr[i - 1] > arr[i])
                    {
                        isRaising = false;
                        if (i == 1) return false;
                    }
                }
                else
                {
                    if (arr[i - 1] <= arr[i]) return false;
                }
            }

            return !isRaising;
        }
    }
}
