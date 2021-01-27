using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ConcatenationOfConsecutiveBinaryNumbers
{
    [TestClass]
    public class ConcatenationOfConsecutiveBinaryNumbers
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(27, ConcatenatedBinary(3));
        }

        public int ConcatenatedBinary(int n)
        {
            var mod = 1000000007L;
            var current = 0L;

            for (var i = 1; i <= n; i++)
            {
                var good = false;
                for (var j = 17; j >= 0; j--)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        good = true;
                        current *= 2;
                        current++;
                    }
                    else if(good)
                    {
                        current *= 2;
                    }

                    current %= mod;
                }
            }

            return (int) current;
        }
    }
}
