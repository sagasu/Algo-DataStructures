using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Regular_Expression_Matching
{
    internal class Regular_Expression_Matching
    {
        int[,] dp;
        public bool IsMatch(string s, string p)
        {
            dp = new int[s.Length, p.Length];
            return IsMathUntil(s, p, s.Length - 1, p.Length - 1);
        }

        public bool IsMathUntil(string s, string p, int i, int j)
        {
            if (i < 0 && j < 0) return true;

            if (j < 0) return false;

            if (i >= 0 && dp[i, j] != 0) return dp[i, j] == 1;

            var res = false;

            if (i >= 0 && s[i] == p[j]) res = IsMathUntil(s, p, i - 1, j - 1);

            if (p[j] == '.' && i >= 0) res = IsMathUntil(s, p, i - 1, j - 1);

            if (p[j] == '*') res = IsMathUntil(s, p, i, j - 2) || (i >= 0 && (s[i] == p[j - 1] || p[j - 1] == '.') && IsMathUntil(s, p, i - 1, j));

            if (i >= 0) dp[i, j] = res ? 1 : -1;

            return res;
        }
    }
}

