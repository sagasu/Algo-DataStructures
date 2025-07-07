using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_Events_That_Can_Be_Attended;

public class Maximum_Number_of_Events_That_Can_Be_Attended
{
    public int MaxEvents(int[][] events) {
        int n = events.Length;
        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

        var pq = new PriorityQueue<int, int>(); 
        int day = 0, result = 0, i = 0;

        while (i < n || pq.Count > 0) {
            if (pq.Count == 0 && day < events[i][0]) {
                day = events[i][0];
            }

            while (i < n && events[i][0] == day) {
                pq.Enqueue(events[i][1], events[i][1]);
                i++;
            }

            while (pq.Count > 0 && pq.Peek() < day) {
                pq.Dequeue();
            }

            if (pq.Count > 0) {
                pq.Dequeue();
                result++;
            }

            day++;
        }

        return result;
    }
}