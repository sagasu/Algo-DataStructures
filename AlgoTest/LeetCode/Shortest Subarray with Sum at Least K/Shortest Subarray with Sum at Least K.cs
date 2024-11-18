using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Shortest_Subarray_with_Sum_at_Least_K;

public class Shortest_Subarray_with_Sum_at_Least_K
{
    public int ShortestSubarray(int[] nums, int k)
    {
        var n = nums.Length;
        var prefixSum = new long[n + 1];
        
        for (int i = 0; i < n; i++)
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        
        var deque = new LinkedList<int>();
        var minLength = int.MaxValue;

        for (int i = 0; i <= n; i++)
        {
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First.Value] >= k)
            {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last.Value])
                deque.RemoveLast();

            deque.AddLast(i);
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}