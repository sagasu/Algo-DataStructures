using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit;

public class Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit
{
    public int LongestSubarray(int[] nums, int limit)
    {
        LinkedList<int> minDeque = new(), maxDeque = new();
        int max = 0, start = 0;
        
        for (var end = 0; end < nums.Length; end++)
        {
            while (minDeque.Last?.Value > nums[end])
                minDeque.RemoveLast();
            minDeque.AddLast(nums[end]);
            
            while (maxDeque.Last?.Value < nums[end])
                maxDeque.RemoveLast();
            maxDeque.AddLast(nums[end]);

            while (maxDeque.First.Value - minDeque.First.Value > limit)
            {
                if (minDeque.First.Value == nums[start])
                    minDeque.RemoveFirst();
                if (maxDeque.First.Value == nums[start])
                    maxDeque.RemoveFirst();
                start++;
            }

            max = Math.Max(max, end - start + 1);
        }

        return max;
    }
}