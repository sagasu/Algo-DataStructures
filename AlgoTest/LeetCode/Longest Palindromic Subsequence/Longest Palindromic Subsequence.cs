using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_Palindromic_Subsequence
{
    [TestClass]
    public class Longest_Palindromic_Subsequence
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(4, LongestPalindromeSubseq("bbbab"));
        [TestMethod]
        public void Test3() => Assert.AreEqual(3, LongestPalindromeSubseq("bbb"));
        [TestMethod]
        public void Test4() => Assert.AreEqual(4, LongestPalindromeSubseq("bbbb"));
        [TestMethod]
        public void Test2() => Assert.AreEqual(2, LongestPalindromeSubseq("cbbd"));

        public int LongestPalindromeSubseq(string s)
        {
            var cache = new int?[s.Length,s.Length];

            int FindLongest(int left, int right)
            {
                if (cache[left, right].HasValue) return cache[left, right].Value;
                if(left == right) return 1;
                if(left > right) return 0;

                var max = 0;
                if (s[left] == s[right])
                    max = Math.Max(max,FindLongest(left + 1, right-1)+2);

                max = Math.Max(max,FindLongest(left+1, right));
                max = Math.Max(max,FindLongest(left, right-1));
                
                cache[left, right] = max;
                return max;
            }

            return FindLongest(0, s.Length-1);
        }
    }
}
