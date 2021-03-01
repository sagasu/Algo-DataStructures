﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Distribute_Candies
{
    [TestClass]
    public class Distribute_Candies2
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(3, DistributeCandies(new int[]{ 1, 1, 2, 2, 3, 3 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, DistributeCandies(new int[] { 1, 1, 2, 3 }));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(1, DistributeCandies(new int[] { 6, 6, 6, 6 }));
        }

        // Runtime cost is high due to Distinct()
        public int DistributeCandies(int[] candyType)
        {
            return Math.Min(candyType.Length / 2, candyType.Distinct().Count());
        }
    }
}
