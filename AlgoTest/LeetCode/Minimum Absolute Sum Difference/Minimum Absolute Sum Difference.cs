using System;

namespace AlgoTest.LeetCode.Minimum_Absolute_Sum_Difference;

public class Minimum_Absolute_Sum_Difference
{
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2) {
        long sum = 0,ans;
        var mod = 1000000007;
        var nums = new int[nums1.Length];

        for(var i = 0; i < nums.Length; i++)
        {
            sum = (sum + Math.Abs(nums1[i] - nums2[i]));
            nums[i] = nums1[i];
        }

        ans = sum;
        Array.Sort(nums1);

        for(var i = 0; i < nums.Length; i++)
        {
            var idx = Array.BinarySearch(nums1, nums2[i]);
            if (idx < 0)
                idx = ~idx;

            var left = idx > 0 ? Math.Abs(nums1[idx - 1] - nums2[i]) : int.MaxValue;
            var right = idx < nums.Length ? Math.Abs(nums1[idx] - nums2[i]) : int.MaxValue;
            var temp = (sum - Math.Abs(nums[i] - nums2[i]) + Math.Min(left, right));

            ans = Math.Min(ans, temp);
        }

        return (int)(ans % mod);
    }
}