using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Other
{
    [TestClass]
    public class Proplem1
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2,Fibo(3));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(5,Fibo(5));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(3,Fibo(4));
        }

        IDictionary<int, int> cache = new Dictionary<int, int>();
        public int Fibo(int n)
        {
            if (n == 1 || n == 2) return 1;
            if (cache.ContainsKey(n)) return cache[n];
            var fib = Fibo(n - 1) + Fibo(n - 2);
            cache[n] = fib;
            return fib;
        }
    }
}
