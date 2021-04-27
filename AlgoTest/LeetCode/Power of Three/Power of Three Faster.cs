using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Power_of_Three
{
    [TestClass]
    public class Power_of_Three_Faster
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(false, IsPowerOfThree(0));
            Assert.AreEqual(true, IsPowerOfThree(9));
            Assert.AreEqual(false, IsPowerOfThree(45));
            Assert.AreEqual(false, IsPowerOfThree(21));
            Assert.AreEqual(true, IsPowerOfThree(27));
            Assert.AreEqual(true, IsPowerOfThree(1));
        }

        public bool IsPowerOfThree(int n)
        {
            if (n < 1) return false;

            while (n % 3 == 0) n /= 3;

            return n == 1;
        }
    }
}
