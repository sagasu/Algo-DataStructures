using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Best_Poker_Hand;

[TestClass]
public class Best_Poker_Hand
{
    [TestMethod]
    public void Test() =>
        Assert.AreEqual("Flush", BestHand(new[] { 13, 2, 3, 1, 9 }, new[] { 'a', 'a', 'a', 'a', 'a' }));
    
    [TestMethod]
    public void Test1() =>
        Assert.AreEqual("Three of a Kind", BestHand(new[] { 4,4,2,4,4}, new[] { 'd','a','a','b','c' }));
    
    [TestMethod]
    public void Test2() =>
        Assert.AreEqual("Pair", BestHand(new[] { 10,10,2,12,9 }, new[] { 'a','b','c','a','d' }));
    
    [TestMethod]
    public void Test3() =>
        Assert.AreEqual("High Card", BestHand(new[] { 13, 2, 3, 1, 9 }, new[] { 'a','b','c','a','d' }));
    
    
    public string BestHand(int[] ranks, char[] suits)
    {
        var max = 0;
        var dic = ranks.GroupBy(rank=> rank).ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
        var firstSuit = suits[0];
        if (suits.All(suit => suit == firstSuit)) return "Flush";

        var dicMaxValue = dic.Values.Max();
        if (dicMaxValue >= 3) return "Three of a Kind";
        if (dicMaxValue == 2) return "Pair";

        return "High Card";
    }
}