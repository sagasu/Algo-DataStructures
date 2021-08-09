using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.Other
{
    [TestClass]
    public class Proplem3
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

        public int Fibo(int n)
        {
            var first = 0;
            var second = 1;
            var third = 0;
            for(var i = 0;i<=n;i++)
            {
                if(i == n) return first;

                second += first;
                third += first;

                first = second;
                second = third;
                third = 0;

            };

            return first;
        }
    }
}
