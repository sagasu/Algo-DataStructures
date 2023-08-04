using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Word_Break
{
    internal class Word_Break
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var n = s.Length;
            var dp = new bool[n + 1];

            dp[0] = true;
            for (var i = 1; i <= n; i++)
            {
                var sIndex = i - 1;
                foreach (var word in wordDict)
                {
                    var wordLen = word.Length;
                    var lastChar = word.Last();

                    if (lastChar == s[sIndex] && sIndex + 1 >= wordLen)
                        if (s.Substring(sIndex - wordLen + 1, wordLen) == word)
                            dp[i] |= dp[i - wordLen];
                        
                    
                }
            }

            return dp[n];
        }
    }
}
