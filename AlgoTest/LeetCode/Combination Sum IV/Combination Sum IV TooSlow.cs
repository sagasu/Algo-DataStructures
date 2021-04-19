using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Combination_Sum_IV
{
    [TestClass]
    public class Combination_Sum_IV_TooSlow
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(7, CombinationSum4(new int[]{1,2,3}, 4));
        }

        IDictionary<string, int> combinations = new Dictionary<string, int>();
        public int CombinationSum4(int[] nums, int target)
        {
            int Dfs(int index, int sum, List<int> numbers)
            {
                if (sum == target)
                {
                    if(combinations.TryAdd(string.Join("_", numbers), 1))
                        return 1;
                    return 0;
                }

                if (sum > target || index == target) return 0;

                var nrOfCombinations = 0;
                index += 1;
                for (var i = 0; i < nums.Length; i++)
                {
                    numbers.Add(nums[i]);
                    nrOfCombinations += Dfs(index, sum + nums[i], numbers);
                    numbers.RemoveAt(numbers.Count - 1);
                    nrOfCombinations += Dfs(index, sum, numbers);
                }

                return nrOfCombinations;
            }

            var ret = Dfs(0, 0, new List<int>());
            return ret;
        }
    }
}
