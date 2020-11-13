using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.FindtheSmallestDivisorGivenaThreshold
{
    [TestClass]
    public class FindtheSmallestDivisorGivenaThreshold
    {
        [TestMethod]
        public void TesT()
        {
            var t = new int[] {1, 2, 5, 9};
            Assert.AreEqual(5, SmallestDivisor(t, 6));

            t = new int[] { 19 };
            Assert.AreEqual(4, SmallestDivisor(t, 5));

            t = new int[] { 2, 3, 5, 7, 11 };
            Assert.AreEqual(3, SmallestDivisor(t, 11));
        }

        public int SmallestDivisor(int[] nums, int threshold)
        {
            var divisor = 1;
            while (true)
            {
                int maxSum = 0;
                foreach (var num in nums)
                {
                    var addOne = (num % divisor) != 0;
                    maxSum += num / divisor;
                    if (addOne)
                        maxSum += 1;
                }

                if (maxSum <= threshold)
                    return divisor;

                divisor += 1;
            }
        }
    }
}
