﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Combination_Sum_IV
{
    [TestClass]
    public class Combination_Sum_IV_CacheSubFromTarget
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(7, CombinationSum4(new int[]{1,2,3}, 4));
        }
        
        
        [TestMethod]
        public void Test2()
        {

            Assert.AreEqual(9, CombinationSum4(new int[]{ 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 10));
        }

        IDictionary<int?, int> cache = new Dictionary<int?, int>();
        
        public int CombinationSum4(int[] nums, int target)
        {
            int Dfs(int rest)
            {
                if (rest == 0) return 1;

                if (rest < 0) return 0;

                if (cache.ContainsKey(rest)) return cache[rest];

                var nrOfCombinations = 0;

                for (var i = 0; i < nums.Length; i++)
                    nrOfCombinations += Dfs(rest - nums[i]);

                cache.TryAdd(rest, nrOfCombinations);
                return nrOfCombinations;
            }

            var ret = Dfs(target);
            return ret;
        }
    }
}
