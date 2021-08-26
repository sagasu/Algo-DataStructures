using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sum_of_Square_Numbers
{
    // The reason it is faster is because we find the b from the end to each i
    // so it is like a window problem that is getting smaller and smaller as i increases b decreases.
    [TestClass]
    public class Sum_of_Square_Numbers
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
            var max = (int)Math.Sqrt(c);
            for (var i = 0; i <= max; i++)
            {
                var b = Math.Sqrt(c - i * i);
                if (b == (int)b)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
