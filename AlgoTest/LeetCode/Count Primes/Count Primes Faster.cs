using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_Primes
{
    [TestClass]

    public class Count_Primes_Faster
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


        //This is Sieve_of_Eratosthenes - take first prime and mark all following multiplications as not prime, then take next number that is prime and repeat. Mixed with sqrt approach, because composite number n must be a multiplications of at least 2 numbers, and one of them needs to be smaller than sqrt of that number.
        public int CountPrimes(int n)
        {
            var count = 0;
            var notPrime = new bool[n];
            if (n <= 1) return 0;

            for (long i = 2; i < Math.Sqrt(n); i++)
            {
                if (!notPrime[i])
                {
                    long multiplications = i * i;
                    while (multiplications < n)
                    {
                        notPrime[multiplications] = true;
                        multiplications += i;
                    }
                }
            }

            for (var i = 2; i < n; i++)
                if (notPrime[i] == false) count += 1;
            

            return count;
        }
    }
}
