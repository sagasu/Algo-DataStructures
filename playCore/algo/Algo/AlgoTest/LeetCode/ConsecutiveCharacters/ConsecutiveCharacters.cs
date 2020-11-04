using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ConsecutiveCharacters
{
    [TestClass]
    public class ConsecutiveCharacters
    {
        [TestMethod]
        public void Test()
        {
            var t = "abbcccddddeeeeedcba";
            Assert.AreEqual(5, MaxPower(t));
        }

        public int MaxPower(string s)
        {
            if (s.Length == 1)
                return 1;

            var localMax = 1;
            var max = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == s[i])
                {
                    localMax += 1;
                }
                else
                {
                    max = Math.Max(max, localMax);
                    localMax = 1;
                }
            }

            return Math.Max(max, localMax);
        }
    }
}
