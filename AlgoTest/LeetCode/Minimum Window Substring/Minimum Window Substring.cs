using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Window_Substring
{
    [TestClass]
    public class Minimum_Window_Substring
    {
        [TestMethod]
        public void Test()
        {
            var s = "ADOBECODEBANC";
            var t = "ABC";
            Assert.AreEqual("BANC", MinWindow(s,t));
        }

        /*
         * Idea is to start by finding a first range with all the needed chars
         * ADOBECODEBANC
         * |    |
         *
         * Then remove the first char and find it at the end
         * ADOBECODEBANC
         *    |      |
         *
         * Here we didn't have to search for B after removing it at the end, because it was already in the range
         * ADOBECODEBANC
         *      |    |  
         *
         * ADOBECODEBANC
         *          |  |
         */

        public string MinWindow(string s, string t)
        {
            var start = 0;
            var end = 0;
            var count = t.Length;
            var freq = new int[128];
            var result = string.Empty;

            foreach (var ch in t) freq[ch]++;

            while (end < s.Length)
            {
                if (freq[s[end++]]-- > 0) count--;

                while (count == 0)
                {
                    if (string.IsNullOrEmpty(result) || end - start < result.Length) result = s.Substring(start, end - start);
                    
                    if (freq[s[start++]]++ == 0) count++;
                }
            }
            return result;
        }

    }
}
