using System;

namespace AlgoTest.LeetCode.Maximum_Product_of_Two_Elements_in_an_Array;

public class Maximum_Product_of_Two_Elements_in_an_Array
{
    public int MaxProduct(int[] nums)
    {
        Array.Sort(nums);
        return (nums[^1] - 1) * (nums[^2] - 1);
    }
}