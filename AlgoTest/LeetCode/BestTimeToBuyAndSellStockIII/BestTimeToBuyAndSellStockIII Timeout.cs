using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BestTimeToBuyAndSellStockIII
{
    [TestClass]
    public class BestTimeToBuyAndSellStockIII_Timeout
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {3, 3, 5, 0, 0, 3, 1, 4};
            Assert.AreEqual(6,MaxProfit(t));
            maxProfit = 0;

            t = new int[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(4,MaxProfit(t));
            maxProfit = 0;

            t = new int[] { 7, 6, 4, 3, 1 };
            Assert.AreEqual(0, MaxProfit(t));
        }

        // This solution times out
        public int MaxProfit(int[] prices)
        {
            Dfs(prices, 0, 0, false, 0, 0);
            return maxProfit;
        }

        int maxProfit = 0;
        private void Dfs(int[] prices, int index, int value, bool isBought, int buyPrice, int nrTransactions)
        {
            if (nrTransactions == 2 || index == prices.Length)
            {
                maxProfit = Math.Max(maxProfit, value);
                return;
            }

            for (var i = index; i < prices.Length; i++)
            {
                if (isBought)
                {
                    if (buyPrice < prices[i])
                    {
                        Dfs(prices, i+1, value + prices[i] - buyPrice, false, 0, nrTransactions+1);
                    }
                }
                else
                {
                    Dfs(prices, i+1, value, isBought, buyPrice, nrTransactions);
                    Dfs(prices, i+1, value, true, prices[i], nrTransactions);
                }


            }
        }
    }
}
