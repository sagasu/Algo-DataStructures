using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SplitaStringIntotheMaxNumberofUniqueSubstrings
{
    public class MaxNumberUniqueSubstrings
    {
        public int MaxUniqueSplit(string s)
        {
            return GetMaxUniqueSubstrings(s, new HashSet<string>());
        }

        public int GetMaxUniqueSubstrings(string s, HashSet<string> seen)
        {
            var max = 0;
            for (var i = 1; i <= s.Length; i++)
            {
                var ss = s.Substring(0, i);
                if (!seen.Contains(ss))
                {
                    seen.Add(ss);
                    max = Math.Max(max, 1 + GetMaxUniqueSubstrings(s.Substring(i), seen));
                    seen.Remove(ss);
                }
            }

            return max;
        }
    }
}
