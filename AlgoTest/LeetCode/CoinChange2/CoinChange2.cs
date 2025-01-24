using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CoinChange2
{
    [TestClass]
    public class CoinChange2
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, Change(5, new[] { 1, 2, 5 }));
            //Assert.AreEqual(35502874, Change(500, new []{3,5,7,8,9,10,11}));
        }

        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount+1];
            dp[0] = 1;

            for (var i = 0; i < coins.Length; i++)
            {
                for (var j = coins[i]; j <= amount; j++)
                    dp[j] += dp[j - coins[i]];
                
            }

            return dp[amount];
        }

        
    }
}
