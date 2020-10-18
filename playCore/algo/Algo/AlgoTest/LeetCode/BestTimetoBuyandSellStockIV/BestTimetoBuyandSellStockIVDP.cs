using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BestTimetoBuyandSellStockIV
{
    [TestClass]
    public class BestTimetoBuyandSellStockIVDP
    {
        [TestMethod]
        public void TesT()
        {
            var t = new int[] { 2, 4, 1 };
            Assert.AreEqual(2, MaxProfit(2, t));


            //var t = new int[] { 3, 2, 6, 5, 0, 3 };
            //Assert.AreEqual(7, MaxProfit(2, t));

            //var t = new int[] {1, 3};
            //Assert.AreEqual(2, MaxProfit(1, t));

        }
        /*    [5, 11, 3, 50, 60, 90]
         * 0   0, 0,  0, 0,  0,  0
         * 1   0, 6,  6, 47, 57, 87
         * 2   0, 6,  6, 53, 63, ?
         *
         *                 | profit[t,d-1]
         *profit[t,d] = max|
         *                 | profit[d] + max(-price[x] + profit[t-1, x])
         *                            for 0 <= x < d
         * x = 0 : -5 + 0 = -5
         * x = 1 : -11+ 6 = -5
         * x = 2 : -3 + 6 = 3
         * x = 3 : -50 + 47 = -3
         * x = 4 : -60 + 57 = -3
         *
         *
         * so ? = profit[t,d] =  90 + 3 = 93
         *
         * time = O(n^2 k)
        */
        public int MaxProfit(int k, int[] prices)
        {
            if (k == 0) return 0;
            var matrix = new int[prices.Length, k];

            for(var i = 1;i < prices.Length;i++)
            for (var j = 0; j < k; j++)
            {
                matrix[i, j] = Math.Max(matrix[i-1, j], matrix[i-1, j] + (prices[i] - prices[i - 1]));
            }

            return matrix[prices.Length - 1, k - 1];
        }
    }
}
