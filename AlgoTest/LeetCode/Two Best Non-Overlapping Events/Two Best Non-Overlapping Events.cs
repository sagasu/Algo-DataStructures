using System;

namespace AlgoTest.LeetCode.Two_Best_Non_Overlapping_Events;

public class Two_Best_Non_Overlapping_Events
{
    public int MaxTwoEvents(int[][] events) {
        Array.Sort(events, (x,y) => x[0].CompareTo(y[0]));
        var cache = new int[events.Length];
        cache[cache.Length-1] = events[events.Length-1][2];
        for(var i = events.Length-2; i >= 0; i--) 
            cache[i] = Math.Max(events[i][2], cache[i+1]); 
        
        var res = 0;
        foreach(var ev in events)
        {
            var val = ev[2];
            var i = search(ev[1], events);
            if(i != -1) val += cache[i];
            res = Math.Max(res, val);
        }
        
        return res;
    }
    
    private int search(int target, int[][] events)
    {
        int lo = 0, hi = events.Length-1;
        while(lo < hi)
        {
            var mid = lo + (hi-lo)/2;
            if(events[mid][0] > target)
                hi = mid;
            else
                lo = mid+1;
        }
        
        return events[lo][0] > target ? lo : -1;
    } 
}