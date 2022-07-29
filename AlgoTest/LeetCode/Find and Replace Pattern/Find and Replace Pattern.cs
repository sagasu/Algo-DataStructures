using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_and_Replace_Pattern
{
    [TestClass]
    public class Find_and_Replace_Pattern
    {
        [TestMethod]
        public void Test()
        {

        }


        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            bool MatchesPattern(string word)
            {
                var matches = word.Length == pattern.Length;
                var patternMap = new Dictionary<char, char>();
                var usedValues = new Dictionary<char, bool>();

                for (var i = 0; i < word.Length && i < pattern.Length && matches; i++)
                {
                    if (patternMap.ContainsKey(pattern[i]))
                        matches = word[i] == patternMap[pattern[i]];
                    else if (usedValues.ContainsKey(word[i]))
                        matches = false;
                    else
                    {
                        patternMap[pattern[i]] = word[i];
                        usedValues[word[i]] = true;
                    }
                }

                return matches;
            }

            var matchingWords = new List<string>();

            foreach (var word in words)
                if (MatchesPattern(word)) matchingWords.Add(word);
            
            return matchingWords;
        }
    }
}
