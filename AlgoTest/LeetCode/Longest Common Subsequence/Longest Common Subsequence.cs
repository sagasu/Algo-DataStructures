using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_Common_Subsequence
{
    [TestClass]
    public class Longest_Common_Subsequence
    {

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, LongestCommonSubsequence("abcde", "ace"));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(3, LongestCommonSubsequence("abc", "abc"));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(0, LongestCommonSubsequence("abc", "def"));
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            var cache = new Dictionary<(int,int), int>();

            int LCS(int i1, int i2)
            {
                if (i1 == text1.Length || i2 == text2.Length) return 0;

                if (cache.ContainsKey((i1, i2))) return cache[(i1, i2)];

                var best = LCS(i1 + 1, i2);
                best = Math.Max(best, LCS(i1, i2 + 1));

                if (text1[i1] == text2[i2])
                    best = Math.Max(best, LCS(i1 + 1, i2 + 1) + 1);

                cache[(i1, i2)] = best;
                return best;
            }

            return LCS(0, 0);
        }
    }
}
