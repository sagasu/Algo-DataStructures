using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.StoneGameIV
{
    [TestClass]
    public class StoneGameIV
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsFalse(WinnerSquareGame(2));
            Assert.IsTrue(WinnerSquareGame(1));
            Assert.IsTrue(WinnerSquareGame(4));
            Assert.IsFalse(WinnerSquareGame(7));
        }

        public bool WinnerSquareGame(int n)
        {
            var powers = new List<int>();
            var powerIndex = 1;
            var nextPower = powerIndex * powerIndex;
            while (nextPower <= n)
            {
                powers.Add(nextPower);
                nextPower = powerIndex * powerIndex;
                powerIndex += 1;
            }

            var isAliceTurn = true;
            var lastPowerUsed = powers.Count-1;
            while (true)
            {
                var largestPower = 0;
                (largestPower, lastPowerUsed) = GetLargestPower(powers, n, lastPowerUsed);
                n -= largestPower;
                if (n == 0)
                    return isAliceTurn;
                isAliceTurn = !isAliceTurn;
            }
        }

        private ValueTuple<int,int> GetLargestPower(List<int> powers, int number, int lastPowerUsed)
        {
            for (var i = lastPowerUsed; i >= 0; i--)
            {
                if (powers[i] <= number)
                    return (powers[i], i);
            }

            throw new ArgumentException();
        }
    }
}
