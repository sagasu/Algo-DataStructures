namespace AlgoTest.LeetCode.Check_if_There_is_a_Valid_Partition_For_The_Array;

public class Check_if_There_is_a_Valid_Partition_For_The_Array
{
    public bool ValidPartition(int[] nums)
    {
        var n = nums.Length;
        var dp = new bool[n, 2];
        dp[0, 0] = false;
        dp[0, 1] = false;

        for (int i = 1; i < n; ++i)
        {
            dp[i, 0] = nums[i] == nums[i - 1];
            if (i > 1)
                dp[i, 0] &= (dp[i - 2, 0] || dp[i - 2, 1]);

            if (i > 1)
                dp[i, 1] = (nums[i] == nums[i - 1] && nums[i - 1] == nums[i - 2]) ||
                           (nums[i] - nums[i - 1] == 1 && nums[i - 1] - nums[i - 2] == 1);
            if (i > 2)
                dp[i, 1] &= (dp[i - 3, 0] || dp[i - 3, 1]);

        }

        return dp[n - 1, 0] || dp[n - 1, 1];
    }
}