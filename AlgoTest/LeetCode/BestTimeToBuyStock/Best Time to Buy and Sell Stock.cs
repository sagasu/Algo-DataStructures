using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.BestTimeToBuyStock
{
    public class Best_Time_to_Buy_and_Sell_Stock
    {
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            var bestSell = 0;
            // We start from the end so we will know the best selling price (the max one) and we move to beginning comparing the profit. 
            for (var i = prices.Length-1; i >= 0; i--)
            {
                maxProfit = Math.Max(maxProfit, bestSell - prices[i]);
                bestSell = Math.Max(bestSell, prices[i]);
            }


            return maxProfit;
        }
    }
}
