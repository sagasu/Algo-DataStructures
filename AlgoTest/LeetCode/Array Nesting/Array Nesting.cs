using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Array_Nesting
{
    class Array_Nesting
    {
        public int ArrayNesting(int[] nums)
        {
            var maxLen = 0;
            var visitedIndexes = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++)
                if (!visitedIndexes.Contains(i))
                    maxLen = Math.Max(maxLen, Dfs(i, new HashSet<int>()));

            return maxLen;

            int Dfs(int index, ISet<int> set)
            {
                if (!set.Add(nums[index])) return set.Count;
                visitedIndexes.Add(index);
                return Dfs(nums[index], set);
            }
        }
    }
}
