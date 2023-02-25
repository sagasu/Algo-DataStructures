using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.BestTimeToBuyStock
{
    //brute force solution, time limit exceeded 
    public class Best_Time_to_Buy_and_Sell_Stock_timelimit
    {
        public int MaxProfit(int[] prices)
        {
            var max = 0;
            for (var i = 0; i < prices.Length; i++)
            for (var j = i + 1; j < prices.Length; j++)
                max = Math.Max(max, prices[j] - prices[i]);

            return max;
        }
    }
}
