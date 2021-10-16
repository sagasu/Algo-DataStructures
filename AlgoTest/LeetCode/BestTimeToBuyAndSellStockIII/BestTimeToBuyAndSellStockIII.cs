using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BestTimeToBuyAndSellStockIII
{
    [TestClass]
    public class BestTimeToBuyAndSellStockIII
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
            var n = prices.Length;
            if (n < 2)
            {
                return 0;
            }
            var dp1 = new int[n];
            var minPrice = prices[0];
            for (var i = 1; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                dp1[i] = Math.Max(dp1[i - 1], prices[i] - minPrice);
            }
            var dp2 = new int[n];
            var maxPrice = prices[n - 1];
            for (var i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                dp2[i] = Math.Max(dp2[i + 1], maxPrice - prices[i]);
            }
            return dp1.Zip(dp2, (x, y) => x + y).Max();
        }
    }
}
