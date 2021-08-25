using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sum_of_Square_Numbers
{
    // Out of time
    [TestClass]
    public class Sum_of_Square_Numbers_OutOfTime
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
        
        // Out of time
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(true, JudgeSquareSum(999999999));

        }
        
        public bool JudgeSquareSum(int c)
        {
            bool IsSquareSum(int a, int b)
            {
                var sum = Math.Pow(a,2) + Math.Pow(b,2);
                if (sum == c) return true;
                if (sum < c) return IsSquareSum(a, b + 1);
                return false;
            }

            
            for (var i = 0; i <= Math.Sqrt(c); i++)
            {
                if (IsSquareSum(i,0)) return true;
            }

            return false;
        }
    }
}
