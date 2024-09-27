using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.My_Calendar_II;

public class MyCalendarTwo
{
    private List<int[]> bookings;
    
    public MyCalendarTwo() 
    {
        bookings = new List<int[]>();
    }
    
    public bool Book(int start, int end) 
    {   
        var overlaps = new List<int[]>();
        foreach(int[] bo in bookings) 
        {
            int overlapStart = Math.Max(bo[0], start), overlapEnd = Math.Min(bo[1], end);
            if (overlapStart < overlapEnd) 
            {
                foreach (int[] ov in overlaps) 
                {
                    if (Math.Max(ov[0], overlapStart) < Math.Min(ov[1], overlapEnd)) 
                    {
                        overlaps.Clear();
                        return false;
                    }
                }
                
                overlaps.Add(new int[] {overlapStart, overlapEnd});
            }
        }
        
        bookings.Add(new int[] {start, end});
        return true;
    }
}