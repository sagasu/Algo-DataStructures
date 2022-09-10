using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BestTimetoBuyandSellStockIV
{
    [TestClass]
    public class BestTimetoBuyandSellStockIV
    {
        [TestMethod]
        public void TesT()
        {
            //var t = new int[] {2, 4, 1};
            //Assert.AreEqual(2, MaxProfit(2, t));


            var t = new int[] { 3, 2, 6, 5, 0, 3 };
            Assert.AreEqual(7, MaxProfit(2, t));

            //var t = new int[] {1, 3};
            //Assert.AreEqual(2, MaxProfit(0, t));

        }

        public int MaxProfit(int k, int[] prices)
        {
            if (k == 0) return 0;
            var maxProfit = 0;
            if (prices.Length / 2 <= k)
            {

                for (var i = 1; i < prices.Length; i++)
                    maxProfit += Math.Max(0, prices[i] - prices[i - 1]);
                
                return maxProfit;
            }

            var buy = new int[k];
            Array.Fill(buy, Int32.MinValue);
            var sell = new int[k];

            // All these calculation are in truth DP, just hidden in name
            for(var i =0; i < prices.Length;i++)
            for (var j = 0; j < k; j++)
            {
                buy[j] = Math.Max(buy[j], j == 0 ? 0 - prices[i] : sell[j - 1] - prices[i]);
                sell[j] = Math.Max(sell[j],buy[j] + prices[i]);
            }

            return sell[k - 1];
        }
    }
}
