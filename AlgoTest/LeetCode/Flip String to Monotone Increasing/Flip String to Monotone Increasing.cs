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

        // Idea is to notice that the order is not important. We are counting how many switches from 1 to 0 we would need to do to make everything 0, and how many switches from 0 to 1 to make everything 1. If we substract both sums from each other we will have the min amount of switches that we would have to make.
        //time O(n)
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
