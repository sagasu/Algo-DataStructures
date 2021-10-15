using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
    class Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
    {
        public int MaxProfit(int[] prices)
        {
            var len = prices.Length;
            var dp = new int[3];
            dp[0] = 0;//hold
            dp[1] = int.MinValue;//buy
            dp[2] = int.MinValue;//sell
            for (var i = 0; i < len; i++)
            {
                int lastHold = dp[0], lastBuy = dp[1];
                dp[0] = dp.Max();
                dp[1] = Math.Max(lastHold - prices[i], dp[1]);
                dp[2] = Math.Max(lastBuy + prices[i], dp[2]);
            }
            return dp.Max();
        }
    }
}
