using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Remove_Palindromic_Subsequences2
{
    [TestClass]
    public class Remove_Palindromic_Subsequences
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(2, RemovePalindromeSub("baabb"));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, RemovePalindromeSub("abb"));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(1, RemovePalindromeSub("ababa"));
        }

        // Trick is to notice that there are only 'a' and 'b' values in string, so if we remove first 'a' substring (subsequence) and then 'b' then there is nothing left. So the worst case scenario is 2. And 0 is when a string is empty.
        // So the question is when do we have 1. We have 1 only when s is a palindrome itself. So we just solve that problem here.
        public int RemovePalindromeSub(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var i = 0;
            var j = s.Length - 1;
            while (true)
            {
                if (i == j || i + 1 == j) return 1;

                if (s[i] != s[j]) break;

                i += 1;
                j -= 1;
            }

            return 2;
        }
    }
}
