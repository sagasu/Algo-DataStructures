using System;

namespace AlgoTest.LeetCode.Find_K_th_Smallest_Pair_Distance;

public class Find_K_th_Smallest_Pair_Distance
{
    public int SmallestDistancePair(int[] nums, int k) 
    {
        Array.Sort(nums);
        
        var left = 0;
        var right = nums[nums.Length - 1] - nums[0];
        
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            
            var count = CountOfLesserThanMid(nums, mid);
            
            if (count < k)
                left = mid + 1;
            else
                right = mid;
            
        }
        
        return left;
    }
    
    private static int CountOfLesserThanMid(int[] nums, int mid)
    {
        var count = 0;
        var left = 0;
        for (var right = 1; right < nums.Length; right++)
        {
            while (nums[right] - nums[left] > mid)
                left++;
            
            count += right - left;
        }
        
        return count;
    }
}