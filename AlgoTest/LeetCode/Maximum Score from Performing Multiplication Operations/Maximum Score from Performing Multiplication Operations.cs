using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Score_from_Performing_Multiplication_Operations
{
    internal class Maximum_Score_from_Performing_Multiplication_Operations
    {
        public int MaximumScore(int[] nums, int[] multipliers)
        {
            var m = multipliers.Length;
            var dp = new int?[m, m];
            return Backtracking(0, 0);

            int Backtracking(int left, int index)
            {
                if (index == m) return 0;

                var right = nums.Length - 1 - index + left;
                return dp[left, index] ??= Math.Max(
                    nums[left] * multipliers[index] + Backtracking(left + 1, index + 1),
                    nums[right] * multipliers[index] + Backtracking(left, index + 1)
                );
            }
        }
    }
}
