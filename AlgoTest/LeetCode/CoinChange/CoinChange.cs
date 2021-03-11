using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CoinChange
{
    [TestClass]
    public class CoinChangeSolution
    {
        [TestMethod]
        public void Test1()
        {
            var t = new int[] {1,2,5 };
            Assert.AreEqual(3, CoinChange(t, 11));
        }

        [TestMethod]
        public void Test2()
        {
            var t = new int[] {2 };
            Assert.AreEqual(-1, CoinChange(t, 3));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] {1};
            Assert.AreEqual(0, CoinChange(t, 0));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {1};
            Assert.AreEqual(2, CoinChange(t, 2));
        }


        public int CoinChange(int[] coins, int amount)
        {
            // It is because in c# it will swith to - number quickly.
            var maxValue = int.MaxValue - 1;
            var cache = new int?[coins.Length, amount + 1];
            
            int GetMinCoinChange(int index, int sum)
            {
                if (sum == 0)
                    return 0;

                if (sum < 0)
                    return maxValue;

                if (index == coins.Length)
                    return maxValue;

                if (cache[index, sum].HasValue) return cache[index, sum].Value;

                var min = maxValue;
                min = Math.Min(min, GetMinCoinChange(index, sum - coins[index]) + 1);

                min = Math.Min(min, GetMinCoinChange(index + 1, sum));

                cache[index, sum] = min;

                return min;
            }

            var minCoinChange = GetMinCoinChange(0, amount);
            return minCoinChange == maxValue ? -1 : minCoinChange;
        }

    }
}
