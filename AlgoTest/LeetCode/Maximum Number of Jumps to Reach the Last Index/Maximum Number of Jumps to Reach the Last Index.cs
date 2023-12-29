using System;

namespace AlgoTest.LeetCode.Maximum_Number_of_Jumps_to_Reach_the_Last_Index;

public class Maximum_Number_of_Jumps_to_Reach_the_Last_Index
{
    public int MaximumJumps(int[] nums, int target) {
        var n = nums.Length;
        var dp = new int[n];

        Array.Fill(dp, -1);
        dp[0] = 0;

        for (var i = 0; i < n; i++)
        {
            if (dp[i] == -1) continue;

            for (var j = i + 1; j < n; j++)
            {
                if (Math.Abs(nums[j] - nums[i]) > target)
                    continue;

                dp[j] = dp[j] == -1 ? dp[i] + 1 : Math.Max(dp[j], dp[i] + 1);
            }
        }

        return dp[n - 1];
    }
}