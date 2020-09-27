using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.WordBreak
{
    [TestClass]
    public class WordBreakSolution
    {
        [TestMethod]
        public void Test()
        {
            var s = "leetcode";
            var wordDict = new string[] {"leet", "code"};
            Assert.IsTrue(WordBreak(s, wordDict));
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (s.Length == 0)
                return true;
            for (var i = 1; i <= s.Length; i++)
            {
                var word = s.Substring(0, i);
                if (wordDict.Contains(word) && WordBreak(s.Substring(i), wordDict)) return true;
            }

            return false;
        }
    }
}
