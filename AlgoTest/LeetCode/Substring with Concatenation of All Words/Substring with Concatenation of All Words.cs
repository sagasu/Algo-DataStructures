using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Substring_with_Concatenation_of_All_Words
{
    internal class Substring_with_Concatenation_of_All_Words
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            if (words.Length == 0) return new List<int>();

            var wordAndCount = new Dictionary<string, int>();
            var existingWordAndCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordAndCount.ContainsKey(word))
                {
                    existingWordAndCount[word] = 0;
                    wordAndCount[word] = 0;
                }

                wordAndCount[word]++;
            }

            var wordLength = words[0].Length;
            var totalLength = wordLength * words.Length;

            var result = new List<int>();

            for (int i = 0; i < s.Length - totalLength + 1; i++)
            {
                var left = i;
                var right = i - 1;
                while (right + 1 + wordLength <= s.Length && right - left + 1 < totalLength)
                {
                    var word = s.Substring(right + 1, wordLength);
                    if (wordAndCount.ContainsKey(word) && wordAndCount[word] > existingWordAndCount[word])
                    {
                        existingWordAndCount[word]++;
                        right += wordLength;
                    }
                    else
                    {
                        break;
                    }
                }

                if (right - left + 1 == totalLength)
                {
                    result.Add(i);
                }

                foreach (var word in words)
                {
                    existingWordAndCount[word] = 0;
                }
            }

            return result;
        }
    }
}
