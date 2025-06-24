using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_All_K_Distant_Indices_in_an_Array;

public class Find_All_K_Distant_Indices_in_an_Array
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        var res = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == key && Math.Abs(i - j) <= k)
                {
                    res.Add(i);
                    break;
                }
            }
        }

        return res;
    }
}