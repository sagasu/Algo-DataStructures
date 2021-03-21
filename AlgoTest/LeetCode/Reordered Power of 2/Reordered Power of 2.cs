using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Reordered_Power_of_2
{
    [TestClass]
    public class Reordered_Power_of_2
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, ReorderedPowerOf2(46));
            Assert.AreEqual(true, ReorderedPowerOf2(1));
            Assert.AreEqual(true, ReorderedPowerOf2(16));
            Assert.AreEqual(false, ReorderedPowerOf2(10));
            Assert.AreEqual(false, ReorderedPowerOf2(24));
        }

        public bool ReorderedPowerOf2(int N)
        {
            string Normalize(double d)
            {
                var number = d.ToString().ToCharArray();
                Array.Sort(number);
                return string.Join("", number);
            }

            var powers = new List<string>(32);

            // N < 10^9 < 2^32
            for (int i = 0; i < 32; i++)
            {
                powers.Add(Normalize(Math.Pow(2,i)));
            }

            var normalized = Normalize(N);
            return powers.Contains(normalized);
        }
    }
}
