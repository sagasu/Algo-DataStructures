using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Score_of_Parentheses
{
    internal class ScoreofParentheses
    {
        public int ScoreOfParentheses(string S)
        {
            int lc = 0, rc = 0, curr = 0;

            for (var i = 0; i < S.Length; i++)
            {
                if (i > 0 && S[i - 1] == ')' && S[i] == '(')
                {
                    curr += lc > 1 ? 1 << (lc - 1) : 1;
                    lc -= rc - 1;
                    rc = 0;
                }
                else if (S[i] == '(') lc++;
                else rc++;
            }

            curr += rc > 1 ? 1 << (rc - 1) : 1;

            return curr;
        }
    }
}
