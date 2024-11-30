using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Time_to_Visit_a_Cell_In_a_Grid;

public class Minimum_Time_to_Visit_a_Cell_In_a_Grid
{
    public int MinimumTime(int[][] grid)
    {
        if (grid[0][1] > 1 && grid[1][0] > 1)
        {
            return -1;
        }

        int row = grid.Length, col = grid[0].Length;
        var directions = new int[][] {
            new int[]{1, 0},
            new int[]{-1, 0},
            new int[]{0, 1},
            new int[]{0, -1}
        };

        var visited = new bool[row][];
        for (int i = 0; i < row; i++)
        {
            visited[i] = new bool[col];
        }

        var pq = new PriorityQueue<(int, int, int), int>();
        pq.Enqueue((0, 0, 0), 0);
        visited[0][0] = true;

        while (pq.Count > 0)
        {
            var (i, j, currentTime) = pq.Dequeue();

            if (i == row - 1 && j == col - 1)
            {
                return currentTime;
            }

            foreach (var direction in directions)
            {
                var newI = i + direction[0];
                var newJ = j + direction[1];

                if (newI >= 0 && newI < row && newJ >= 0 && newJ < col && !visited[newI][newJ])
                {
                    if (currentTime + 1 >= grid[newI][newJ])
                    {
                        pq.Enqueue((newI, newJ, currentTime + 1), currentTime + 1);
                    }
                    else
                    {
                        var newTime = grid[newI][newJ] - currentTime;
                        if (newTime % 2 == 0)
                        {
                            newTime += 1;
                        }

                        pq.Enqueue((newI, newJ, newTime + currentTime), newTime + currentTime);
                    }

                    visited[newI][newJ] = true;
                }
            }
        }

        return -1;
    }
}