using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Decode_Ways
{
    public class Decode_Ways
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var length = s.Length;
            var dp = new int[length];

            for (var i = 0; i < length; i++)
            {
                var current = s[i];
                var isZero = current == '0';

                if (i == 0)
                {
                    dp[0] = isZero ? 0 : 1;

                    if (isZero) return 0;
                }

                if (i > 0 && !isZero) dp[i] += dp[i - 1];

                if (i >= 1 && s[i - 1] != '0' &&
                    ToNumber(current, s[i - 1]) <= 26 &&
                    ToNumber(current, s[i - 1]) > 0)
                {
                    if (i == 1) dp[i] += 1;

                    if (i >= 2) dp[i] += dp[i - 2];
                }
            }

            return dp[length - 1];
        }

        private static int ToNumber(char current, char left)
        {
            var number = left - '0';
            number *= 10;
            number += current - '0';

            return number;
        }
    
    }
}
