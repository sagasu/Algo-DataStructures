using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Difference_Between_Largest_and_Smallest_Value_in_Three_Moves;

public class Minimum_Difference_Between_Largest_and_Smallest_Value_in_Three_Moves
{
    public int MinDifference(int[] nums) {
        if (nums.Length < 5) return 0;

        Array.Sort(nums);

        return Enumerable.Range(0, 4)
            .Select(x => nums.Skip(x).Take(nums.Length - 3).ToArray())
            .Select(x => x[nums.Length - 4] - x[0])
            .Min();
    }
}