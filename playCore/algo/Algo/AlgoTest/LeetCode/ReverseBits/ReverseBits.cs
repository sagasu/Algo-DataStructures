using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ReverseBits
{
    [TestClass]
    public class ReverseBitsProblem
    {
        [TestMethod]
        public void Test()
        {
            uint t = 43261596;
            uint expected = 964176192;
            Assert.AreEqual(expected ,reverseBits(t));
        }

        public uint reverseBits(uint n)
        {
            uint ret = 0;
            for (var i = 0; i < 32; i++)
            {
                var nextBit = n & 1;
                n >>= 1;
                ret = ret << 1;
                ret = ret | nextBit;
            }

            return ret;
        }
    }
}
