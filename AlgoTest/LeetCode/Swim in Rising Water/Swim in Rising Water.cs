using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Swim_in_Rising_Water;

public class Swim_in_Rising_Water
{
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        if (n == 1) return grid[0][0];

        int t = Math.Max(grid[0][0], grid[n - 1][n - 1]);
        int[][] dirs = new int[][] {
            new int[] {1, 0}, new int[] {-1, 0},
            new int[] {0, 1}, new int[] {0, -1}
        };

        while (true) {
            if (grid[0][0] > t) { 
                t++;
                continue;
            }

            var q = new Queue<(int,int)>();
            var visited = new bool[n,n];
            q.Enqueue((0,0));
            visited[0,0] = true;

            while (q.Count > 0) {
                var (i,j) = q.Dequeue();

                foreach (var d in dirs) {
                    int x = i + d[0], y = j + d[1];
                    if (x < 0 || y < 0 || x >= n || y >= n) continue;
                    if (!visited[x,y] && grid[x][y] <= t) {
                        if (x == n - 1 && y == n - 1) return t;
                        visited[x,y] = true;
                        q.Enqueue((x,y));
                    }
                }
            }

            t++;
        }
    }
}