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
            //Assert.AreEqual(5, Change(5, new []{1,2,5}));
            Assert.AreEqual(5, Change(500, new []{3,5,7,8,9,10,11}));
        }

        private int amount;
        private int[] coins;
        private int ways = 0;
        public int Change(int amount, int[] coins)
        {
            this.amount = amount;
            this.coins = coins;

            CalculateChange(0, 0);
            return ways;
        }

        public void CalculateChange(int value, int index)
        {
            if (value == amount)
            {
                ways += 1;
                return;
            }

            if(value > amount)
                return;

            for (var i = index; i < coins.Length; i++)
            {
                CalculateChange(value + coins[i], i);
            }
        }
    }
}
