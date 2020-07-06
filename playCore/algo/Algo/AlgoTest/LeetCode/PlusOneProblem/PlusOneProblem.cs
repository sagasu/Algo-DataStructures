using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PlusOneProblem
{
    [TestClass]
    public class PlusOneProblem
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2, PlusOne(new[] {9}).Length);
        }

        public int[] PlusOne(int[] digits)
        {
            var cary = false;
            var incNumber = digits[digits.Length - 1] + 1;
            if (incNumber >= 10)
            {
                incNumber = 0;
                cary = true;
            }

            digits[digits.Length - 1] = incNumber;

            if (!cary)
                return digits;


            for (var i = digits.Length - 2; i >= 0; i--)
            {
                if (cary)
                {
                    cary = false;
                    incNumber = digits[i] + 1;
                    if (incNumber >= 10)
                    {
                        incNumber = 0;
                        cary = true;
                    }
                    digits[i] = incNumber;
                }
                
            }

            if (cary)
            {
                var ret = new int[digits.Length + 1];
                Array.Copy(digits,0,ret,1, digits.Length);
                ret[0] = 1;
                return ret;
            }

            return digits;
        }
    }
}
