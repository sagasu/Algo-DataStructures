using System;

namespace AlgoTest.LeetCode.Find_if_Array_Can_Be_Sorted;

public class Find_if_Array_Can_Be_Sorted
{
    public bool CanSortArray(int[] nums)
    {
        var lastPopCount = 0;
        var lastMax = 0;
        var max = 0;
        foreach(var num in nums)
        {
            var popCount = int.PopCount(num);
            if (popCount == lastPopCount)
                max = Math.Max(max, num);
            
            else
            {
                lastPopCount = popCount;
                lastMax = max;
                max = num;
            }
            
            if (num < lastMax)
                return false;
            
        }
        return true;
    }
}