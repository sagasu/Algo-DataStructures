using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Partitions_With_Max_Min_Difference_at_Most_K;

public class Count_Partitions_With_Max_Min_Difference_at_Most_K
{
    public int CountPartitions(int[] nums, int k)
    {
        int n = nums.Length;
        int[] dp = new int[n + 1];
        int[] prefix = new int[n + 2];
        int MOD = 1_000_000_007;
        dp[0] = 1;
        prefix[1] = 1;
        int left = 0;

        LinkedList<int> maxDeque = new LinkedList<int>();
        LinkedList<int> minDeque = new LinkedList<int>();

        for (int right = 0; right < n; right++)
        {
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] < nums[right])
                maxDeque.RemoveLast();

            maxDeque.AddLast(right);

            while (minDeque.Count > 0 && nums[minDeque.Last.Value] > nums[right])
                minDeque.RemoveLast();

            minDeque.AddLast(right);

            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > k)
            {
                if (maxDeque.First.Value == left) maxDeque.RemoveFirst();
                if (minDeque.First.Value == left) minDeque.RemoveFirst();

                left++;
            }

            dp[right + 1] = (prefix[right + 1] - prefix[left] + MOD) % MOD;
            prefix[right + 2] = (prefix[right + 1] + dp[right + 1]) % MOD;
        }

        return dp[n];
    }
}