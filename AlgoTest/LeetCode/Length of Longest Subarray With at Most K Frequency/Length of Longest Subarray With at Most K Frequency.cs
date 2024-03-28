using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Length_of_Longest_Subarray_With_at_Most_K_Frequency;

public class Length_of_Longest_Subarray_With_at_Most_K_Frequency
{
    public int MaxSubarrayLength(int[] nums, int k) {
        var res = 0;
        var i = 0; 
        var j = 0;
        Dictionary<int, int> dict = new();
        while(i <= j && j < nums.Length) {
            if(!dict.ContainsKey(nums[j])) 
                dict.Add(nums[j], 0);
            dict[nums[j]]++;
            while(dict[nums[j]] > k)
                dict[nums[i++]]--;
            j++;
            res = Math.Max(res, j - i);
        }

        return res;
    }
}