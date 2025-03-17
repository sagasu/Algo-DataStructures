using System;

namespace AlgoTest.LeetCode.Maximum_Count_of_Positive_Integer_and_Negative_Integer;

public class Maximum_Count_of_Positive_Integer_and_Negative_Integer
{
    public int MaximumCount(int[] nums)
    {
        var countNegative = 0;
        var countPositive = 0;
        foreach (var num in nums)
        {
            if (num > 0) countPositive++;
            if (num < 0) countNegative++;
        }

        return Math.Max(countNegative, countPositive);
    }
}