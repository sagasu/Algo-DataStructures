using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Wildcard_Matching
{
    internal class Wildcard_Matching
    {
        public bool IsMatch(string s, string p)
        {
            var nS = s.Length;
            var nP = p.Length;

            var dp = new bool[nS + 1, nP + 1];
            dp[0, 0] = true;
            
            for (var i = 0; i < nS + 1; i++)
            {
                var sIndex = i - 1;
                for (var j = 1; j < nP + 1; j++)
                {
                    var pIndex = j - 1;

                    if (p[pIndex] == '*')
                        dp[i, j] = dp[i, j - 1] || (i > 0 && (dp[i - 1, j - 1] || dp[i - 1, j]));
                    else if (i > 0 && p[pIndex] == '?')
                        dp[i, j] = dp[i - 1, j - 1];
                    else if (i > 0 && s[sIndex] == p[pIndex])
                        dp[i, j] = dp[i - 1, j - 1];
                    
                }
            }

            return dp[nS, nP];
        }
    }
}
