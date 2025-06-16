using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Difference_Between_Increasing_Elements;

public class Maximum_Difference_Between_Increasing_Elements
{
    public int MaximumDifference(int[] nums) => nums.
        Aggregate((min: int.MaxValue, max: -1), (curr, num) =>
            (
                min: Math.Min(curr.min, num), 
                current: curr.min < num ? Math.Max(num - curr.min, curr.max) : curr.max
            ),
            curr => curr.max); 
}