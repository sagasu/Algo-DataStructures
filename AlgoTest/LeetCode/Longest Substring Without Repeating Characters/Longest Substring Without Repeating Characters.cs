using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_Substring_Without_Repeating_Characters
{
    internal class Longest_Substring_Without_Repeating_Characters
    {
        Dictionary<char, int> dic = new();

        public int LengthOfLongestSubstring(string s)
        {
            var max = 0;
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                    j = Math.Max(j, dic[s[i]] + 1);
                
                dic.Add(s[i], i);
                max = Math.Max(i - j + 1, max);
            }

            return max;
        }
    }
}
