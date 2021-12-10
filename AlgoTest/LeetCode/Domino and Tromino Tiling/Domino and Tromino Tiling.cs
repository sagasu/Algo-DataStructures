using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Domino_and_Tromino_Tiling
{
    class Domino_and_Tromino_Tiling
    {
        public int NumTilings(int n)
        {
            var mod = (int)Math.Pow(10, 9) + 7;
            var dp = new long[4];

            for (var i = 1; i <= n; i++)
            {
                if (i == 1) dp[i] = 1;
                else if (i == 2) dp[i] = 2;
                else if (i == 3) dp[i] = 5;
                else dp[i % 4] = (2 * dp[(i - 1) % 4] + dp[(i - 3) % 4]) % mod; //f(n) = 2f(n - 1) + f(n - 3)
            }

            return (int)dp[n % 4];
        }
    }
}
