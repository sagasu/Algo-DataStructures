using System;

public class MinimumSizeSubarraySum {
    public int MinSubArrayLen(int s, int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }

        int res = int.MaxValue;
        int left = 0;
        int sum = nums[0];
        int right = 0;

        while (left != nums.Length)
        {
            if (sum < s)
            {
                if (right < nums.Length - 1)
                {
                    right++;
                    sum += nums[right];
                }
                else
                {
                    sum -= nums[left];
                    left++;
                }

                continue;
            }

            res = Math.Min(right - left + 1, res);
            sum -= nums[left];
            left++;
        }

        return res == int.MaxValue ? 0 : res;
    }
}