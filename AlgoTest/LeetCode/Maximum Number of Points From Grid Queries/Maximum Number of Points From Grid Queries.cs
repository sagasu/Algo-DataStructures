using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_Points_From_Grid_Queries;

public class Maximum_Number_of_Points_From_Grid_Queries
{
    public int[] MaxPoints(int[][] grid, int[] queries) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int n = queries.Length;
        int[] ans = new int[n];
        var indexedQueries = new (int value, int index)[n];

        for (int i = 0; i < n; i++) {
            indexedQueries[i] = (queries[i], i);
        }

        Array.Sort(indexedQueries, (a, b) => a.value.CompareTo(b.value));

        var pq = new SortedSet<(int value, int row, int col)>();
        pq.Add((grid[0][0], 0, 0));
        bool[,] visited = new bool[rows, cols];
        visited[0, 0] = true;
        int count = 0;

        var directions = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (int i = 0; i < n; i++) {
            int limit = indexedQueries[i].value;
            int index = indexedQueries[i].index;
            
            while (pq.Count > 0 && pq.Min.value < limit) {
                var (val, r, c) = pq.Min;
                pq.Remove(pq.Min);
                count++;

                foreach (var (dr, dc) in directions) {
                    int newRow = r + dr;
                    int newCol = c + dc;
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow, newCol]) {
                        visited[newRow, newCol] = true;
                        pq.Add((grid[newRow][newCol], newRow, newCol));
                    }
                }
            }
            
            ans[index] = count;
        }

        return ans;
    }
}