using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Substring_with_Concatenation_of_All_Words
{
    internal class Substring_with_Concatenation_of_All_WordsSolution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var wordCount = words[0].Length;
            IDictionary<string, int> hist = new Dictionary<string, int>(), currHist = new Dictionary<string, int>();
            foreach (string w in words) hist[w] = hist.ContainsKey(w) ? hist[w] + 1 : 1;
            for (var i = 0; i < wordCount; i++)
            {
                currHist.Clear();
                for (int j = i, k = i; j + words.Length * wordCount <= s.Length; k += wordCount)
                {
                    var word = s.Substring(k, wordCount);
                    if (!hist.ContainsKey(word))
                    {
                        currHist.Clear();
                        j = k + wordCount;
                        continue;
                    }
                    currHist[word] = currHist.ContainsKey(word) ? currHist[word] + 1 : 1;
                    if (currHist[word] > hist[word])
                        while (currHist[word] > hist[word])
                        {
                            currHist[s.Substring(j, wordCount)]--;
                            j += wordCount;
                        }
                    else if ((k - j) / wordCount == words.Length - 1)
                    {
                        result.Add(j);
                        currHist[s.Substring(j, wordCount)]--;
                        j += wordCount;
                    }
                }
            }
            return result;
        }
    }
}
