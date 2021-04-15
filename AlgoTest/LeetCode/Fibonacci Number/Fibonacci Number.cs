using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Fibonacci_Number
{
    [TestClass]
    public class Fibonacci_Number
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, Fib(4));
        }

        IDictionary<int, int> cache = new Dictionary<int, int>();
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (cache.ContainsKey(n)) return cache[n];

            var fibNumber = Fib(n - 1) + Fib(n - 2);
            cache.TryAdd(n, fibNumber);
            return fibNumber;
        }
    }
}
