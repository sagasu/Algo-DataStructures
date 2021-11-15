using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Largest_Divisible_Subset
{
    class Largest_Divisible_Subset
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            IList<int> res = new List<int>();

            if (nums.Length == 0) return res;

            Array.Sort(nums);

            int[] dp = new int[nums.Length], prev = new int[nums.Length];

            var maxIndex = 0;

            Array.Fill(dp, 1);

            for (var i = 1; i < nums.Length; i++)
            for (var j = 0; j < i; j++)
                if (nums[i] % nums[j] == 0 && dp[i] < dp[j] + 1)
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j + 1;
                    if (dp[i] > dp[maxIndex]) maxIndex = i;
                }
                
            

            do
            {
                res.Add(nums[maxIndex]);
            } while ((maxIndex = prev[maxIndex] - 1) != -1);

            return res;
        }
    }
}
