using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.BestTimeToBuyStock
{
    class BestTimeToBuyStock
    {
        public int MaxProfit(int[] prices)
        {
            return MaxProfit(prices, 0, -1);
        }

        //solution for Best Time to Buy and Sell Stock II
        // buying and selling next day.
        // this is what LeetCode is looking for, but it has so many assumptions... the real solution is dynamic programming.
        public int MaxProfitNaiveImplementation(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            var profit = 0;
            for (var i = 0; i < prices.Length-1; i++)
            {
                if (prices[i + 1] > prices[i])
                {
                    profit += prices[i + 1] - prices[i];
                }
            }

            return profit;
        }


        //solution for Best Time to Buy and Sell Stock I, that is in dynamic programming section!,
        // again very naive solution
        public int MaxProfitINaiveImplementation(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            var minValue = int.MaxValue;
            var maxProfit = 0;

            for (var i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minValue)
                {
                    minValue = prices[i];
                }else if (prices[i] - minValue > maxProfit)
                {
                    maxProfit = prices[i] - minValue;
                }
            }

            return maxProfit;
        }

        // beginning of dynamic programming implementation.
        public int MaxProfit(int[] prices, int index, int stockPrice)
        {
            var profit = 0;
            for (int i = index; i < prices.Length; i++)
            {
                //buy
                if (stockPrice == -1)
                {
                    MaxProfit(prices, i+1, prices[index]);
                }

                //sell
                if (stockPrice < prices[i])
                {
                    profit = prices[i] - stockPrice;
                    stockPrice = -1;
                }

                
            }
            return profit;
        }
    }
}
