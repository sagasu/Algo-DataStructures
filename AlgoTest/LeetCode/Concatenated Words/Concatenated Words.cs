using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Concatenated_Words
{
    internal class Concatenated_Words
    {

        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {

            List<string> res = new List<string>();
            if (words == null || words.Length == 0)
                return res;

            HashSet<string> wordSet = new HashSet<string>();
            Array.Sort(words, (a, b) => a.Length - b.Length);
            foreach (var word in words)
            {
                if (IsConcatenated(word, wordSet))
                    res.Add(word);

                wordSet.Add(word);
            }

            return res;
        }

        public bool IsConcatenated(string word, HashSet<string> wordSet)
        {
            if (wordSet.Count == 0)
                return false;

            bool[] dp = new bool[word.Length + 1];
            dp[0] = true;

            for (int i = 1; i <= word.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordSet.Contains(word.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[word.Length];
        }
    }
        
}
