using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PowXN
{
    [TestClass]
    public class PowXN2
    {
        [TestMethod]
        public void Test()
        {
            MyPow(0.00001, 2147483647);
        }

        public double MyPow(double x, int n)
        {
            if (n == 1)
                return x;

            if (n == 0)
                return 1;

            if (n < 0)
                return 1/MyPow(x, -1 * n);

            if (n > 0)
                return x * MyPow(x, n - 1);

            throw new ArgumentException("this shouldn't happen");
        }
    }
}
