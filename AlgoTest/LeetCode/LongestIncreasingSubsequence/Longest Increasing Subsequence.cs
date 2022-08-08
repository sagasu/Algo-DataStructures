using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.LongestIncreasingSubsequence
{
    internal class Longest_Increasing_Subsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            Array.Fill(dp, 1);
            var max = 1;
            for (var i = 0; i < nums.Length; i++)
            for (var j = 0; j < i; j++)
            {
                if (nums[i] <= nums[j]) continue;
                dp[i] = Math.Max(dp[i], dp[j] + 1);

                max = Math.Max(max, dp[i]);
            }
            

            return max;
        }
    }
}
