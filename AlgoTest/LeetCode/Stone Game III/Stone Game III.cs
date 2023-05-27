using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Stone_Game_III
{
    internal class Stone_Game_III
    {
        public string StoneGameIII(int[] stoneValue)
        {
            var dp = new int[stoneValue.Length];

            dp[stoneValue.Length - 1] = stoneValue[^1];

            for (var i = stoneValue.Length - 2; i >= 0; i--)
            {
                dp[i] = int.MinValue;

                var sum = 0;
                for (var j = 0; j < 3 && i + j < stoneValue.Length; j++)
                {
                    sum += stoneValue[i + j];
                    dp[i] = Math.Max(dp[i], sum - (i + j + 1 >= stoneValue.Length ? 0 : dp[i + j + 1]));
                }
            }

            return dp[0] switch
            {
                0 => "Tie",
                < 0 => "Bob",
                _ => "Alice"
            };
        }

    }
}
