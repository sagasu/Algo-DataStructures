using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.K_Inverse_Pairs_Array
{
    internal class K_Inverse_Pairs_Array
    {
        public int KInversePairs(int n, int k)
        {
            var dp = new int[n + 1, k + 1];

            for (var i = 0; i <= n; i++)
            for (var j = 0; j <= k; j++)
                dp[i, j] = -1;
                
            int Inverse(int n, int k)
            {
                long res = 0;

                if (k == 0) return 1;
                
                if (n == 0 || k < 0) return 0;
                
                if (dp[n, k] != -1) return dp[n, k];
                
                res = Inverse(n - 1, k) + Inverse(n, k - 1) - Inverse(n - 1, k - n);

                dp[n, k] = (int)((res + 1_000_000_007) % 1_000_000_007);

                return dp[n, k];
            }

            return Inverse(n, k);
        }

        
    }
}
