using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximal_Score_After_Applying_K_Operations;

public class Maximal_Score_After_Applying_K_Operations
{
    public long MaxKelements(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a,b) => b.CompareTo(a) ));
        foreach (var num in nums)
            pq.Enqueue(num, num);
        
        long score = 0;

        while(k>0)
        {
            var num = pq.Dequeue();
            score += num;
            pq.Enqueue((int)Math.Ceiling((decimal)num/3), (int)Math.Ceiling((decimal)num / 3));
            k--;
        }

        return score;
    }
}