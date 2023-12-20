using System;

namespace AlgoTest.LeetCode.Buy_Two_Chocolates;

public class Buy_Two_Chocolates
{
    public int BuyChoco(int[] prices, int money) {
        Array.Sort(prices);
        var cur = prices[0] + prices[1];
        return cur > money ? money : money - cur;
    }
}