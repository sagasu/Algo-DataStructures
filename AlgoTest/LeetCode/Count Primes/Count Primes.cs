using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_Primes
{
    [TestClass]

    public class Count_Primes
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
            Assert.AreEqual(41537, CountPrimes(499979));
        }

        public int CountPrimes(int n)
        {
            var count = 0;
            var primes = new bool[n];
            if (n <= 1) return 0;

            Array.Fill(primes, true);
            primes[0] = false;
            primes[1] = false;

            for (long i = 2; i < n; i++)
            {
                if (primes[i])
                {
                    count += 1;
                    long j = i * i;
                    while (j < n)
                    {
                        primes[j] = false;
                        j += i;
                    }
                }
            }

            return count;
        }
    }
}
