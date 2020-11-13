using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LongestDuplicateSubstring
{
    [TestClass]
    public class LongestDuplicateSubstringProblem
    {
        [TestMethod]
        public void Test()
        {
            var t = "banana";
            Assert.AreEqual("ana",LongestDupSubstring(t));
        }


        public string LongestDupSubstring(string S)
        {
            if (string.IsNullOrEmpty(S))
                return "";

            var dp = new int[S.Length+1,S.Length+1];
            var max = 0;
            var indexRow = 0;
            for (var row = 0; row < S.Length; row++) {
                for (var column = 0; column < S.Length; column++)
                {
                    if (S[row] == S[column] && row != column)
                    {
                        dp[row+1, column+1] = dp[row, column] + 1;
                        if (dp[row+1, column+1] > max)
                        {
                            max = dp[row+1, column+1];
                            indexRow = row;
                        }
                    }
                }
            }

            if (max > 0)
            {
                return S.Substring(indexRow - max +1, max);
            }

            return "";
        }
    }
}
