using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Longest_Square_Streak_in_an_Array;

public class Longest_Square_Streak_in_an_Array
{
    public int LongestSquareStreak(int[] nums) 
    {
        var result = -1;
        var ss = new SortedSet<int>(nums);
        Array.Sort(nums);
        
        while(ss.Any())
        {
            var cur = ss.Min;
            ss.Remove(cur);
            var count = 1;
            
            while(ss.Contains(cur * cur))
            {
                ss.Remove(cur * cur);
                count++;
                cur = cur * cur;
            }
            
            if (count >= 2)
                result = Math.Max(result, count);
        }
        
        return result;
    }
}