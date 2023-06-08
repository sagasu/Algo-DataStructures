using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Cost_to_Cut_a_Stick
{
    internal class Minimum_Cost_to_Cut_a_Stick
    {
        public int MinCost(int n, int[] cuts)
        {
            Array.Sort(cuts);
            var m = cuts.Length;
            var dp = new int[m + 2, m + 2];

            for (var l = 2; l <= m + 1; l++)
                for (var i = 0; i + l <= m + 1; i++)
                {
                    var j = i + l;
                    dp[i, j] = int.MaxValue;
                    for (var k = i + 1; k < j; k++)
                        dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k, j]);


                    var left = i == 0 ? 0 : cuts[i - 1];
                    var right = j == m + 1 ? n : cuts[j - 1];
                    dp[i, j] += right - left;
                }


            return dp[0, m + 1];
        }
    }
}
