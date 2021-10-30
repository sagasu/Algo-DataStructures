using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.LongestDuplicateSubstring
{
    class Longest_Duplicate_Substring
    {
        public string LongestDupSubstring(string s)
        {
            var answer = "";
            var charPosition = new Dictionary<char, List<int>>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!charPosition.ContainsKey(s[i])) charPosition.Add(s[i], new List<int>());
                
                charPosition[s[i]].Add(i);
            }

            foreach (var pair in charPosition.Where(pair => s.Length - pair.Value[0] > answer.Length))
            {
                for (var i = 0; i < pair.Value.Count - 1; i++)
                {
                    if (s.Length - pair.Value[i + 1] > answer.Length)
                    {
                        for (var j = i + 1; j < pair.Value.Count; j++)
                        {
                            var index1 = pair.Value[i];
                            var index2 = pair.Value[j];
                            while (index1 < s.Length && index2 < s.Length && s[index1] == s[index2])
                            {
                                ++index1;
                                ++index2;
                            }

                            if (index1 - pair.Value[i] > answer.Length) answer = s.Substring(pair.Value[i], index1 - pair.Value[i]);
                        }
                    }
                }
            }
            return answer;
        }
    }
}
