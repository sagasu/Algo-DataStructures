using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Min_Cost_to_Connect_All_Points;

public class Min_Cost_to_Connect_All_PointsSolution
{
    HashSet<int[]> visited = new();
    PriorityQueue<(int[] point, int wt), int> heap = new();

    public int MinCostConnectPoints(int[][] points) {
        heap.Enqueue((points[0], 0), 0);

        var total = 0;
        while (heap.Count > 0 && visited.Count < points.Length) {
            var tuple = heap.Dequeue();
            if (visited.Contains(tuple.point)) continue;

            total += tuple.wt;
            visited.Add(tuple.point);

            foreach (var point in points) {
                if (visited.Contains(point)) continue;
         
                var distance = GetDistance(point, tuple.point);
                heap.Enqueue((point, distance), distance);
            }
        }
        
        return total;
    }
    private static int GetDistance(int[] a, int[] b) => Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
    
}