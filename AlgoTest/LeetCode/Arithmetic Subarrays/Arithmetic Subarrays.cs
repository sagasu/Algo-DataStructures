using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Arithmetic_Subarrays;

public class Arithmetic_Subarrays
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r) {
        var ans = new List<bool>();
        
        for (var i = 0; i < l.Length; i++)
        {
            var arr = new int[r[i] - l[i] + 1];
            Array.Copy(nums, l[i], arr, 0, r[i] - l[i] + 1);
            Array.Sort(arr);
            ans.Add(IsArithmetic(arr));
        }
        
        return ans;
    }
    
    bool IsArithmetic(int[] arr)
    {
        var diff = arr[1] - arr[0];
        for (var i = 2; i < arr.Length; i++)
            if (arr[i] - arr[i - 1] != diff)
                return false;
        
        return true;
    }
}