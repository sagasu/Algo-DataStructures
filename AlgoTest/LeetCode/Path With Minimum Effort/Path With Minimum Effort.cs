using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Path_With_Minimum_Effort;

public class Path_With_Minimum_Effort
{
    public int MinimumEffortPath(int[][] heights)
    {
        var rows = heights.Length;
        var columns = heights[0].Length;

        var queue = new PriorityQueue<(int row,int column),int>();
        var visited = new Dictionary<(int, int), int>();

        queue.Enqueue((0,0), 0);
        visited.Add((0,0), 0);

        while(queue.TryDequeue(out var coordinate, out var diff))
        {
            var (i, j) = coordinate;
            if(i == rows - 1 && j == columns - 1)
                return diff;
            

            var height = heights[i][j];
            foreach(var (newI, newJ) in new[]{(i-1,j),(i+1,j),(i,j-1),(i,j+1)})
            {
                if(newI < 0 || newI > rows - 1 || newJ < 0 || newJ > columns - 1)
                    continue;
                
                var newHeight = heights[newI][newJ];
                var newDiff = Math.Max(diff, Math.Abs(newHeight - height));
                
                if(!visited.ContainsKey((newI, newJ)) || visited[(newI, newJ)] > newDiff)
                {
                    queue.Enqueue((newI, newJ), newDiff);
                    visited[(newI, newJ)] = newDiff;
                }
            }
        }
        
        return -1;
    }
}