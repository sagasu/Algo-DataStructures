using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
{
    [TestClass]
    public class Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 3, 2, 8, 4, 9};
            Assert.AreEqual(8, MaxProfit(t, 2));
        }

        


        // I love this approach instead of doing DP, it is a recursive bottom up approach for DP.

        public int MaxProfit(int[] prices, int fee)
        {
            var BuyStockCache = new int?[prices.Length];
            var HoldStockCache = new int?[prices.Length];

            int BuyStock(int day)
            {
                if (day == prices.Length) return 0;
                if (BuyStockCache[day].HasValue) return BuyStockCache[day].Value;

                var buyStock = HoldStock(day + 1) - prices[day];
                var doNothing = BuyStock(day + 1);

                var max = Math.Max(buyStock, doNothing);
                BuyStockCache[day] = max;
                return max;
            }

            int HoldStock(int day)
            {
                if (day == prices.Length) return 0;
                if (HoldStockCache[day].HasValue) return HoldStockCache[day].Value;

                var sellStock = BuyStock(day + 1) + prices[day]  - fee;
                var hold = HoldStock(day + 1);

                var max = Math.Max(sellStock, hold);
                HoldStockCache[day] = max;
                return max;
            }

            return BuyStock(0);
        }
    }
}
