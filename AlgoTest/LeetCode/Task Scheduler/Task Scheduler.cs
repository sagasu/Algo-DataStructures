using System;

namespace AlgoTest.LeetCode.Task_Scheduler;

public class Task_Scheduler
{
    public int LeastInterval(char[] tasks, int n) {
        var freq = new int[26];
        foreach(char ch in tasks)
            freq[ch-'A']++;
			
        int max = 0, maxCount = 0;
        foreach (var t in freq)
        {
            if(t > max)
            {
                max = t;
                maxCount = 1;
            } 
            else if(t == max)
                maxCount++;
        }
        
        return Math.Max(max+n*(max-1)+maxCount-1, tasks.Length);
    }
}