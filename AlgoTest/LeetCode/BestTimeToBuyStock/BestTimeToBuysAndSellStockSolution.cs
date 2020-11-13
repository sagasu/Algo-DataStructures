using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.BestTimeToBuyStock
{
    class BestTimeToBuysAndSellStockSolution
    {

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0 || prices.Length == 1)
                return 0;

            return GetMaxProfit(prices, 1, int.MinValue, prices[0]);
        }

        // O(n), we are in one interation finding max profit between minValue = minPrice and maxProfit that we already calculated.
        public int GetMaxProfit(int[] prices, int index, int maxProfit, int minPrice)
        {
            if (index > prices.Length - 1)
                return Math.Max(0, maxProfit);

            maxProfit = Math.Max(maxProfit, prices[index] - minPrice);
            minPrice = Math.Min(minPrice, prices[index]);
            return GetMaxProfit(prices, index + 1, maxProfit, minPrice);
        }
    }
}
