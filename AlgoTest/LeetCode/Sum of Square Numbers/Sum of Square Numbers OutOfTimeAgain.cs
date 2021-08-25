using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sum_of_Square_Numbers
{
    [TestClass]
    public class Sum_of_Square_Numbers_OutOfTimeAgain
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
        
        public bool JudgeSquareSum(int c)
        {
            var squares = new List<double>();
            for (var i = 0; i <= Math.Sqrt(c); i++)
            {
                squares.Add(Math.Pow(i,2));
            }

            for (var i = 0; i <= squares.Count/2; i++)
            {
                for (var j = i; j < squares.Count; j++)
                {
                    var sum = squares[i] + squares[j];
                    if (sum == c) return true;
                    if (sum > c) break;
                }
            }
            return false;
        }
    }
}
