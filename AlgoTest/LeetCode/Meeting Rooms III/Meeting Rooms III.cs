using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Meeting_Rooms_III;

public class Meeting_Rooms_III
{
    public int MostBooked(int n, int[][] meetings) {
        var rooms = new int[n];
        var occupiedRooms = new PriorityQueue<List<long>, long>(Comparer<long>.Create((x, y) => x.CompareTo(y)));
        
        var freeRooms = new PriorityQueue<long, long>();
        for (var i = 0; i < n; i++)
            freeRooms.Enqueue(i, i);
        
        
        Array.Sort(meetings, (x, y) => x[0].CompareTo(y[0]));
        long currentTime = 0;
        foreach (var meeting in meetings)
        {
            currentTime = Math.Max(meeting[0], currentTime);
            
            if (freeRooms.Count == 0) {
                var earliestFreeTime = occupiedRooms.Peek()[1];
                currentTime = Math.Max(earliestFreeTime, currentTime);
            }            
            
            while (occupiedRooms.Count > 0 && occupiedRooms.Peek()[1] <= currentTime) {
                var freedRoom = occupiedRooms.Dequeue()[2];
                freeRooms.Enqueue(freedRoom, freedRoom);
            }
            
            var nextRoom = freeRooms.Dequeue();
            rooms[nextRoom] += 1;
            occupiedRooms.Enqueue(new List<long>{ currentTime, currentTime + (meeting[1] - meeting[0]), nextRoom }, currentTime + (meeting[1] - meeting[0]));
        }
        
        int max = 0, ansRoom = 0;
        for (var i = n-1; i >= 0; i--) {
            if (rooms[i] >= max) {
                max = rooms[i];
                ansRoom = i;
            }
        }
        
        return ansRoom;
    }
}