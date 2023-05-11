using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Uncrossed_Lines
{
    internal class Uncrossed_Lines
    {
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            var dp = new int[m + 1, n + 1];

            for (var i = 1; i <= m; i++)
            for (var j = 1; j <= n; j++)
                if (nums1[i - 1] == nums2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            
            return dp[m, n];
        }
    }
}
