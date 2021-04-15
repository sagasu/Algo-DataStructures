using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Integer_Break
{
    //https://leetcode.com/problems/integer-break/
    [TestClass]
    public class Integer_Break_Solution
    {

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(36, IntegerBreak(10));
            Assert.AreEqual(9, IntegerBreak(6));
            Assert.AreEqual(12, IntegerBreak(7));
        }

        /*
         * 6 -> 1 1 1 1 1 1 = 1
         * 6 -> 2 2 2 = 8
         * 6 -> 3 3 = 9
         *
         * 7 -> 3 3 1 -> 9
         * 7 -> 2 2 2 1 -> 8
         * 7 -> 3 2 2 -> 12
         */

        public int IntegerBreak(int n)
        {
            if (n == 2) return 1;
            if (n == 3) return 2;

            var product = 1;
            while (n > 0)
            {
                if (n == 4)
                {
                    product *= 4;
                    n -= 4;
                    break;
                }

                if (n >= 3)
                {
                    product *= 3;
                    n -= 3;
                    continue;
                }

                product *= 2;
                n -= 2;
            }

            return product;
        }
    }
}
