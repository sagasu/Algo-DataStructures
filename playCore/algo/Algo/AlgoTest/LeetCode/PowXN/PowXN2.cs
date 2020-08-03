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
            //MyPow(0.00001, 2147483647);
            MyPow(1, -2147483648); // I don't like this test case, because it is specific for long
        }

        public double MyPow(double x, int n)
        {
            return MyPowPrecision(x, n);
        }

        public double MyPowPrecision(double x, long n)
        {
            if (n == 1)
                return x;

            if (n == 0)
                return 1;

            if (n < 0)
                return 1 / MyPowPrecision(x, -1 * ((long)n));

            if (n > 0)
            {
                if (n % 2 == 0)
                    return MyPowPrecision(x * x, n / 2);

                return x * MyPowPrecision(x, n - 1);
            }


            throw new ArgumentException("this shouldn't happen");
        }
    }
}
