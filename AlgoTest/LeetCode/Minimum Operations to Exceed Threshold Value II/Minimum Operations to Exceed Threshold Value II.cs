using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Operations_to_Exceed_Threshold_Value_II;

public class Minimum_Operations_to_Exceed_Threshold_Value_II
{
    public int MinOperations(int[] nums, int k) 
    {
        PriorityQueue<long, long> pq = new();
        var count = 0;
        
        foreach(var num in nums) pq.Enqueue(num, num);
    
        while(pq.Peek() < k)
        {
            var a = pq.Dequeue();
            var b = pq.Dequeue();
            
            var val = Math.Min(a, b) * 2 + Math.Max(a, b);
            pq.Enqueue(val, val);
            
            count++;
        }
        
        return count;
    }
}