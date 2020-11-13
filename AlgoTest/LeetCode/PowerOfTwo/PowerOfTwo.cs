using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PowerOfTwo
{
    [TestClass]
    public class PowerOfTwo
    {
        [TestMethod]
        public void Test() {
            Assert.AreEqual(true, IsPowerOfTwo(16));
            Assert.AreEqual(true, IsPowerOfTwo(512));
        }
        public bool IsPowerOfTwo(int n)
        {
            if (n == 1)
                return true;

            if (n <= 0)
                return false;

            var bits = Convert.ToString(n, 2);//new BitArray(new int[]{n});

            if (bits[0] != '1')
                return false;

            for (var i = 1; i < bits.Length; i++) {
                if (bits[i] != '0')
                    return false;
            }

            return true;
        }
    }
}
