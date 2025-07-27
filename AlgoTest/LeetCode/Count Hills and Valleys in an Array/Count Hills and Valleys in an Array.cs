using System;
using System.Linq;

namespace AlgoTest.LeetCode.Count_Hills_and_Valleys_in_an_Array;

public class Count_Hills_and_Valleys_in_an_Array
{
    public int CountHillValley(int[] nums) =>
        nums.Skip(1).Aggregate(
            (Previous: nums[0], Direction: 0, Count: 0),
            (a, n) => n == a.Previous
                ? a
                : (
                    Previous: n,
                    Direction: Math.Sign(n - a.Previous),
                    Count: a.Direction != 0 && Math.Sign(n - a.Previous) != a.Direction ? a.Count + 1 : a.Count
                )
        ).Count;
}