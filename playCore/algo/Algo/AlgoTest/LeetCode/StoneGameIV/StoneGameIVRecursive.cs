using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.StoneGameIV
{
    [TestClass]
    // This solution doesn't work
    public class StoneGameIVRecursive
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsFalse(WinnerSquareGame(2));
            Assert.IsTrue(WinnerSquareGame(1));
            Assert.IsTrue(WinnerSquareGame(4));
            Assert.IsFalse(WinnerSquareGame(7));
            Assert.IsTrue(WinnerSquareGame(8));
        }

        bool?[] mnemo = new bool?[100001];
        public bool WinnerSquareGame(int n)
        {


            if (n == 0)
                return false;
            if (mnemo[n].HasValue)
                return mnemo[n].Value;

            for (var i = 1; i * i <= n ; i++)
            {
                var num = n - i * i;
                mnemo[num] = WinnerSquareGame(num);
                if (!mnemo[num].Value)
                    return true;
            }

            return false;
        }

    }
}
