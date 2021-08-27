using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Longest_Uncommon_Subsequence_II
{
    class Longest_Uncommon_Subsequence_II
    {
        public int FindLUSlength(string[] strs)
        {
            bool IsSubSequence(string x, string y)
            {
                var j = 0;
                for (var i = 0; i < y.Length && j < x.Length; i++)
                    if (y[i] == x[j]) j += 1;
                return j == x.Length;
            }

            Array.Sort(strs, (a, b) => b.Length.CompareTo(a.Length));
            for (var i = 0; i < strs.Length; i++)
            {
                var j = 0;
                for (j = 0; j < strs.Length; j++)
                {
                    if (i == j) continue;
                    if (IsSubSequence(strs[i], strs[j])) break;
                }

                if (j == strs.Length) return strs[i].Length;
            }

            return -1;
        }


    }
}
