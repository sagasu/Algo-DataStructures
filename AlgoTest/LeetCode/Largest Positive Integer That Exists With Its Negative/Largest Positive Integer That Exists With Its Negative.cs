using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Largest_Positive_Integer_That_Exists_With_Its_Negative;

public class Largest_Positive_Integer_That_Exists_With_Its_Negative
{
    public int FindMaxK(int[] nums) {
        Array.Sort(nums);
        HashSet<int> set = new(nums);
        
        for(var i = nums.Length - 1; i >= 0; i--)
        {
            if(nums[i] < 0) return -1;
            if(set.Contains(-nums[i])) return nums[i];
        }
        
        return -1;
    }
}