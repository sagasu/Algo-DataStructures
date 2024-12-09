using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Special_Array_II;

public class Special_Array_II
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        var indexes = new List<int>();

        for (var i = 1; i < nums.Length; i++)
            if (nums[i] % 2 == nums[i - 1] % 2)
                indexes.Add(i);

        return Array.ConvertAll(queries, query =>
        {
            var i0 = Math.Abs(indexes.BinarySearch(query[0]) + 1);
            var i1 = Math.Abs(indexes.BinarySearch(query[1]) + 1);
            return i0 == i1;
        });
    }
}