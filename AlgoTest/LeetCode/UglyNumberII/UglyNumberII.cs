﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.UglyNumberII
{
    [TestClass]
    public class UglyNumberII
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(12, NthUglyNumber(10));
            Assert.AreEqual(2, NthUglyNumber(2));
        }

        public int NthUglyNumber(int n)
        {
            var i2 = 0;
            var i3 = 0;
            var i5 = 0;
            var nums = new List<int>();
            nums.Add(1);
            while (n > 1)
            {
                var next2 = 2 * nums[i2];
                var next3 = 3 * nums[i3];
                var next5 = 5 * nums[i5];
                var min = Math.Min(next2, Math.Min(next3, next5));

                if (min == next2)
                    i2 += 1;
                else if (min == next3)
                    i3 += 1;
                else
                    i5 += 1;

                if (!nums.Contains(min))
                {
                    nums.Add(min);
                    n -= 1;
                }
            }

            return nums[nums.Count - 1];
        }
    }
}
