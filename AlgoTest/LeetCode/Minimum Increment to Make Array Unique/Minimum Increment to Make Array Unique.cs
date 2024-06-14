using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Increment_to_Make_Array_Unique;

public class Minimum_Increment_to_Make_Array_Unique
{
    public int MinIncrementForUnique(int[] nums, int prev = int.MinValue) =>
        nums.Order().Sum(num => (prev = Math.Max(num, prev + 1)) - num);
}