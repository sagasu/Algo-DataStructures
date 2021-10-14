using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Perfect_Squares
{
    class Perfect_Squares
    {
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                var a = 1;
                var min = i;
                while (a * a <= i)
                {
                    if (dp[i - a * a] + 1 < min)
                    {
                        min = dp[i - a * a] + 1;
                    }
                    a++;
                }
                dp[i] = min;
            }
            return dp[n];
        }
    }
}
