using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BestTimeToBuyAndSellStockIII
{
    [TestClass]
    public class BestTimeToBuyAndSellStockIII_Nicer
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {3, 3, 5, 0, 0, 3, 1, 4};
            Assert.AreEqual(6,MaxProfit(t));

            t = new int[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(4,MaxProfit(t));

            t = new int[] { 7, 6, 4, 3, 1 };
            Assert.AreEqual(0, MaxProfit(t));
        }

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            
            var profit = 0;
            for (var i = 0; i < prices.Length - 1; i++)
                if (prices[i + 1] > prices[i]) profit += prices[i + 1] - prices[i];
            
            return profit;
        }
    }
}
