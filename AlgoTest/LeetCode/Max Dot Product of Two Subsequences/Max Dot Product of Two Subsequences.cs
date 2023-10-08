using System;

namespace AlgoTest.LeetCode.Max_Dot_Product_of_Two_Subsequences;

public class Max_Dot_Product_of_Two_Subsequences
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        var dp = new long[nums1.Length, nums2.Length];
        for (var i = 0; i < nums1.Length; i++)
        for (var j = 0; j < nums2.Length; j++)
        {
            dp[i, j] = int.MinValue;
            dp[i, j] = Math.Max(dp[i, j], nums1[i] * nums2[j]);

            dp[i, j] = Math.Max(dp[i, j], (i > 0 && j > 0) ? dp[i - 1, j - 1] : int.MinValue);
            dp[i, j] = Math.Max(dp[i, j], (i > 0) ? dp[i - 1, j] : int.MinValue);
            dp[i, j] = Math.Max(dp[i, j], (j > 0) ? dp[i, j - 1] : int.MinValue);
            dp[i, j] = Math.Max(dp[i, j], (i > 0 && j > 0) ? dp[i - 1, j - 1] + nums1[i] * nums2[j] : int.MinValue);
        }


        return (int)dp[nums1.Length - 1, nums2.Length - 1];
    }
}