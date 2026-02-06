using System;

namespace AlgoTest.LeetCode.Minimum_Removals_to_Balance_Array;

public class Minimum_Removals_to_Balance_Array
{
    public int MinRemoval(int[] nums, int k) {
        Array.Sort(nums);
        int left = 0;
        int right = 0;
        int min = int.MaxValue;

        for(right = 0; right < nums.Length; right++) {
            
            while((long)nums[right] > (long)nums[left]*k) {
                left++;
            }

            min = Math.Min(nums.Length-(right-left+1), min);
        }

        return min;
    }
}