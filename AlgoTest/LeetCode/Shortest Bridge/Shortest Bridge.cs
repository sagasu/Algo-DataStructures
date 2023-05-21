using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Shortest_Bridge
{
    internal class Shortest_Bridge
    {
        public int ShortestBridge(int[][] grid)
        {
            var dirs = new int[4][]
            {
             new int[]{0, 1},
             new int[]{-1, 0},
             new int[]{1, 0},
             new int[]{0, -1},
            };

            var queue = new Queue<(int, int)>();
            var visited = new bool[grid.Length, grid.Length];

            var row = 0;
            var col = 0;

            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid.Length; j++)
                    if (grid[i][j] == 1)
                    {
                        row = i;
                        col = j;
                        break;
                    }
            
            DFS(grid, row, col, dirs, queue, visited);

            var level = 0;

            while (queue.Count > 0)
            {
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (r, c) = queue.Dequeue();

                    foreach (var dir in dirs)
                    {
                        var newr = r + dir[0];
                        var newc = c + dir[1];

                        if (newr >= 0 && newc >= 0 && newr < grid.Length && newc < grid.Length && !visited[newr, newc])
                        {
                            if (grid[newr][newc] == 1)
                                return level;
                            
                            queue.Enqueue((newr, newc));
                            visited[newr, newc] = true;
                            
                        }
                    }
                }

                level++;
            }

            return level;
        }

        private void DFS(int[][] grid, int i, int j, int[][] dirs, Queue<(int, int)> q, bool[,] visited)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid.Length || grid[i][j] == 0 || visited[i, j])
                return;
            
            q.Enqueue((i, j));
            visited[i, j] = true;

            foreach (var dir in dirs)
            {
                var newi = i + dir[0];
                var newj = j + dir[1];

                DFS(grid, newi, newj, dirs, q, visited);
            }
        }
    }
}
