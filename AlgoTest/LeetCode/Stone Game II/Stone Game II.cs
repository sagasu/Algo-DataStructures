using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Stone_Game_II
{
    internal class Stone_Game_II
    {
        public int StoneGameII(int[] piles)
        {
            var n = piles.Length;
            if (n <= 2) return n;

            var prefixSum = new int[n];
            prefixSum[n - 1] = piles[n - 1];
            
            for (var i = n - 2; i >= 0; i--)
                prefixSum[i] = prefixSum[i + 1] + piles[i];
            

            var dp = new int[n, n];
            PlayGame(dp, 0, 1);
            
            return dp[0, 1];

            int PlayGame(int[,] dp, int idx, int m)
            {
                if (idx >= n) return 0;

                if (idx + (2 * m) >= n) return prefixSum[idx];

                if (dp[idx, m] != 0) return dp[idx, m];

                var max = int.MaxValue;
                for (var i = 1; i <= (2 * m); i++)
                    max = Math.Min(max, PlayGame(dp, (idx + i), Math.Max(m, i)));

                dp[idx, m] = prefixSum[idx] - max;
                return dp[idx, m];
            }
        }
    }
}
