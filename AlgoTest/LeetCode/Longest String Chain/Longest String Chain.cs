using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_String_Chain
{
    [TestClass]
    //Not working fully
    public class Longest_String_Chain
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] {"a", "b", "ba", "bca", "bda", "bdca"};
            Assert.AreEqual(4,LongestStrChain(t));
        }
        
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" };
            Assert.AreEqual(5,LongestStrChain(t));
        }

        public int LongestStrChain(string[] words)
        {
            Array.Sort(words, (a,b) => a.Length.CompareTo(b.Length));

            var best = 0;
            var dp = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var bestPrev = 0;
                for (var i = 0; i < word.Length; i++)
                {
                    var prevWord = word.Substring(0, i - 1 < 0 ? 0 : i-1) + word.Substring(i, word.Length-i);
                    if (dp.ContainsKey(prevWord))
                        bestPrev = Math.Max(bestPrev, dp[prevWord]);
                }

                dp[word] = bestPrev + 1;

            }

            return dp.Values.Max();
        }
    }
}
