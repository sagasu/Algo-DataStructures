using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sum_of_Square_Numbers
{
    [TestClass]
    public class Sum_of_Square_Numbers_OutOfTimeButGettingBetter
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, JudgeSquareSum(5));
            Assert.AreEqual(true, JudgeSquareSum(4));
            Assert.AreEqual(true, JudgeSquareSum(2));
            Assert.AreEqual(true, JudgeSquareSum(1));
            Assert.AreEqual(false, JudgeSquareSum(3));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(false, JudgeSquareSum(999999999));

        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(false, JudgeSquareSum(2147483646));

        }
        
        public bool JudgeSquareSum(int c)
        {
            var a = 0;
            while (2 * a * a <= c)
            {
                var b = Math.Pow(c - a * a, 0.5);
                if (Math.Pow((int) b, 2) + a * a == c) return true;
                a += 1;
            }

            return false;
        }
    }
}
