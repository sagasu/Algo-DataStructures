using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Safest_Path_in_a_Grid;

public class Find_the_Safest_Path_in_a_Grid
{
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        var distance = GetDistance(grid);
        var n = grid.Count;
        var safeness = new int[n][];
        for (var i = 0; i < n; i++) {
            safeness[i] = new int[n];
            Array.Fill(safeness[i], -1);
        }

        var queue = new PriorityQueue<(int, int, int), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        queue.Enqueue((0, 0, distance[0][0]), distance[0][0]);
        safeness[0][0] = distance[0][0];
        var visited = new HashSet<(int, int)>();
        while (queue.Count > 0) {
            (var i, var j, var s) = queue.Dequeue();
            foreach ((var i1, var j1) in new[] { (i + 1, j), (i - 1, j), (i, j + 1), (i, j - 1) }) {
                if (i1 < 0 || i1 >= n || j1 < 0 || j1 >= n || safeness[i1][j1] >= s || visited.Contains((i1, j1))) {
                    continue;
                }
                safeness[i1][j1] = Math.Min(distance[i1][j1], s);
                visited.Add((i1, j1));
                queue.Enqueue((i1, j1, safeness[i1][j1]), safeness[i1][j1]);
            }
        }
        return safeness[n - 1][n - 1];
    }

    private int[][] GetDistance(IList<IList<int>> grid) {
        var n = grid.Count;
        var distance = new int[n][];
        for (var i = 0; i < n; i++) {
            distance[i] = new int[n];
            Array.Fill(distance[i], int.MaxValue);
        }
        var queue = new Queue<(int, int, int)>();
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.Enqueue((i, j, 0));
                }
            }
        }
        while (queue.Any()) {
            (var i, var j, var dist) = queue.Dequeue();
            if (distance[i][j] < dist) {
                continue;
            }
            distance[i][j] = dist;
            foreach ((var i1, var j1) in new[] { (i + 1, j), (i - 1, j), (i, j + 1), (i, j - 1) }) {
                if (i1 < 0 || i1 >= n || j1 < 0 || j1 >= n || distance[i1][j1] <= dist + 1) {
                    continue;
                }
                distance[i1][j1] = dist + 1;
                queue.Enqueue((i1, j1, dist + 1));
            }
        }
        return distance;
    }
}