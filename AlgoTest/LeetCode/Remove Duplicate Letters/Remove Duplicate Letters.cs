using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Remove_Duplicate_Letters
{
    internal class Remove_Duplicate_Letters
    {
        public string RemoveDuplicateLetters(string s)
        {
            Stack<int> st = new(), st2 = new();
            var used = new bool[26];
            var count = new int[26];

            for (var i = 0; i < s.Length; i++) count[s[i] - 'a']++;
            foreach (var t in s)
            {
                var c = t - 'a';
                if (used[c]) { count[c]--; continue; }

                while (st.Count > 0 && st.Peek() >= c && count[st.Peek()] > 0) used[st.Pop()] = false;

                st.Push(c);
                count[c]--;
                used[c] = true;
            }

            while (st.Count > 0) st2.Push(st.Pop());

            var sb = new StringBuilder();
            while (st2.Count > 0) sb.Append((char)(st2.Pop() + 'a'));

            return sb.ToString();
        }
    }
}
