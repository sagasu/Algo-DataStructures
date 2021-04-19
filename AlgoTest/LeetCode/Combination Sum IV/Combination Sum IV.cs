using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Combination_Sum_IV
{
    [TestClass]
    public class Combination_Sum_IV
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
            int Dfs(int sum)
            {
                if (sum == target) return 1;

                if (sum > target) return 0;

                if (cache.ContainsKey(sum)) return cache[sum];

                var nrOfCombinations = 0;

                for (var i = 0; i < nums.Length; i++)
                    nrOfCombinations += Dfs(sum + nums[i]);

                cache.TryAdd(sum, nrOfCombinations);
                return nrOfCombinations;
            }

            var ret = Dfs(0);
            return ret;
        }
    }
}
