using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Longest_Increasing_Subsequence
{
    internal class Number_of_Longest_Increasing_Subsequence
    {
        public int FindNumberOfLIS(int[] nums)
        {
            var dp = nums.Select(_ => (len: 1, count: 1)).ToArray();
            var max = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                var last = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] <= nums[j] || dp[j].len + 1 < dp[i].len)
                        continue;
                    
                    if (last == dp[j].len)
                        dp[i] = (dp[i].len, dp[i].count + dp[j].count);
                    else
                        dp[i] = (dp[j].len + 1, dp[j].count);
                    
                    max = Math.Max(max, dp[i].len);
                    last = dp[j].len;
                }
            }

            return dp.Sum(e => e.len == max ? e.count : 0);
        }
    }
}
