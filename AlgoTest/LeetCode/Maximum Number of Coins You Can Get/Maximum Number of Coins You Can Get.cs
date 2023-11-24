using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Maximum_Number_of_Coins_You_Can_Get;

[TestClass]
public class Maximum_Number_of_Coins_You_Can_Get
{
    [TestMethod]
    public void Test() => Assert.AreEqual(9, MaxCoins(new[] { 2, 4, 1, 2, 7, 8 })); 
    
    public int MaxCoins(int[] piles) {
        Array.Sort(piles);
        var ans = 0;
        
        for (var i = piles.Length / 3; i < piles.Length; i += 2) 
            ans += piles[i];
        
        return ans;
    }
}