using System;

namespace AlgoTest.LeetCode.Shortest_Subarray_With_OR_at_Least_K_II;

public class Shortest_Subarray_With_OR_at_Least_K_II
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        var left = 0;
        var min = int.MaxValue;
        var bitFreq = new int[32];

        for (int right = 0; right < nums.Length; right++)
        {
            var curr = AddToFreq(nums[right], bitFreq);

            while (left <= right && curr >= k)
            {
                min = Math.Min(min, right - left + 1);
                curr = RemoveFromFreq(nums[left], bitFreq);
                left++;
            }
        }

        return min == int.MaxValue ? -1 : min;
    }

    private int RemoveFromFreq(int val, int[] bitFreq)
    {
        var result = 0;
        var mask = 1;
        
        for (int i = 0; i < bitFreq.Length; i++)
        {
            if ((val & mask) > 0)
                bitFreq[i]--;
            
            if (bitFreq[i] != 0)
                result |= mask;

            mask <<= 1;
        }

        return result;
    }

    private int AddToFreq(int val, int[] bitFreq)
    {
        var mask = 1;
        var result = 0;
        for (int i = 0; i < bitFreq.Length; i++)
        {
            if ((val & mask) > 0)
                bitFreq[i]++;
            
            if (bitFreq[i] != 0)
                result |= mask;

            mask <<= 1;
        }

        return result;
    }
}