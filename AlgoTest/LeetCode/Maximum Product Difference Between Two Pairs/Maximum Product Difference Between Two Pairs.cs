using System;

namespace AlgoTest.LeetCode.Maximum_Product_Difference_Between_Two_Pairs;

public class Maximum_Product_Difference_Between_Two_Pairs
{
    public int MaxProductDifference(int[] nums)
    {
        Array.Sort(nums);
        return (nums[^2] * nums[^1]) - (nums[0] * nums[1]);
    }
}