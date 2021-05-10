using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_Primes
{
    [TestClass]
    public class Count_Primes_Timeout
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, CountPrimes(10));
            Assert.AreEqual(4, CountPrimes(11));
            Assert.AreEqual(6, CountPrimes(14));
            Assert.AreEqual(0, CountPrimes(0));
            Assert.AreEqual(0, CountPrimes(1));
            Assert.AreEqual(0, CountPrimes(2));
        }
        // Too slow
        public int CountPrimes(int n)
        {
            var count = 0;
            for (var i = 2; i < n; i++)
            {
                var isPrime = true;
                var boundry = Math.Sqrt(i);
                for (var j = 2; j <= boundry; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    } 
                }

                if (isPrime) count += 1;
            }

            return count;
        }
    }
}
