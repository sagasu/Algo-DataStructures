using System.Collections.Generic;

namespace AlgoTest.LeetCode.Wiggle_Sort_II;

public class Wiggle_Sort_II
{
    public void WiggleSort(int[] nums) 
    {
        var n = nums.Length;
        var pq = new PriorityQueue<int, int>();
        for(int i = 0; i < n; ++i)
            pq.Enqueue(nums[i], -nums[i]);
        
        for(int i = 1; i < n; i = i + 2)
            nums[i] = pq.Dequeue();
        
        for(int i = 0; i < n; i = i + 2)
            nums[i] = pq.Dequeue();
    }
}