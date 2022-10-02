using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Dice_Rolls_With_Target_Sum
{
    internal class Number_of_Dice_Rolls_With_Target_Sum
    {
		public int NumRollsToTarget(int n, int k, int target)
		{
			var dp = new int[target + 1];
			dp[0] = 1;

			for (var i = 1; i <= n; i++)
			{
				var tmp = new int[dp.Length];

				for (var j = 1; j <= target; j++)
				{
					if (j > i * k) continue;

					for (var m = 1; m <= k && m <= j; m++)
                        tmp[j] = (tmp[j] + dp[j - m]) % 1_000_000_007;
					
				}

				dp = tmp;
			}

			return dp[target];
		}
	}
}
