using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Reverse_Only_Letters
{
    class Reverse_Only_Letters
    {
        public string ReverseOnlyLetters(string s)
        {
            var letters = new List<char>();
            var idx2SpecialChar = new Dictionary<int, char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    letters.Add(s[i]);
                    continue;
                }

                if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    letters.Add(s[i]);
                    continue;
                }

                idx2SpecialChar[i] = s[i];
            }

            letters.Reverse();
            var sb = new StringBuilder(s.Length);
            var letterIdx = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (idx2SpecialChar.ContainsKey(i))
                {
                    sb.Append(idx2SpecialChar[i]);
                    continue;
                }

                sb.Append(letters[letterIdx++]);
            }

            return sb.ToString();
        }
    }
}
