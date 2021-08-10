using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Flip_String_to_Monotone_Increasing
{
    [TestClass]
    public class Flip_String_to_Monotone_Increasing
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2, MinFlipsMonoIncr("010110"));
            Assert.AreEqual(2, MinFlipsMonoIncr("00011000"));
            Assert.AreEqual(1, MinFlipsMonoIncr("00110"));
        }

        public int MinFlipsMonoIncr(string s)
        {
            // number of flips from 0 to 1
            var ones = s.Count(c => c == '1');
            // numbers of flips from 1 to 0
            var zeros = 0;

            var best = ones;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0') zeros += 1;
                else ones -= 1;
                best = Math.Min(zeros + ones, best);
            }

            return best;
        }
    }
}
