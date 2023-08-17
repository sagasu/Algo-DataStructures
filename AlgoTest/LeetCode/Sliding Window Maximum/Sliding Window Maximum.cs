using System.Collections.Generic;

namespace AlgoTest.LeetCode.Sliding_Window_Maximum;

public class Sliding_Window_Maximum
{
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        var queue = new PriorityQueue<int, int>();

        var result = new int[nums.Length - k + 1];
        for (var i = 0; i < nums.Length; i++)
        {
            while (queue.Count > 0 && i - k >= queue.Peek())
                queue.Dequeue();
            
            queue.Enqueue(i, -nums[i]);

            if (i >= k - 1)
                result[i - (k - 1)] = nums[queue.Peek()];
        }

        return result;
    }
}