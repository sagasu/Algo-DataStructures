using System;

namespace AlgoTest.LeetCode.Partition_Array_for_Maximum_Sum;

public class Partition_Array_for_Maximum_Sum
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        var len = arr.Length;
        var d = new int[len + 1];
        for(var i = len - 1; i >= 0; i--) {
            var max = 0;
            for(var j = i; j <= len - 1 && j < i + k; j++) {
                max = Math.Max(max, arr[j]);
                d[i] = Math.Max(d[i], max * (j - i + 1) + d[j + 1]);
            }
        }
        
        return d[0];
    }
}