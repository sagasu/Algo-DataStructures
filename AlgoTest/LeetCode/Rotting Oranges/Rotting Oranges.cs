using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Rotting_Oranges
{
    class Rotting_Oranges
    {
        public int OrangesRotting(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            int minutes = 0, fresh = 0;
            var rotten = new Queue<int[]>();

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2) rotten.Enqueue(new int[] { i, j });
                    else if (grid[i][j] == 1) fresh++;
                }
            }

            if (fresh == 0) return 0;

            var dirs = new List<int[]>{
                new int[]{1,0},
                new int[]{-1,0},
                new int[]{0,1},
                new int[]{0,-1}
            };

            while (rotten.Any())
            {
                minutes++;
                var count = rotten.Count;
                for (var i = 0; i < count; i++)
                {
                    var point = rotten.Dequeue();
                    foreach (int[] dir in dirs)
                    {
                        var x = point[0] + dir[0];
                        var y = point[1] + dir[1];
                        if (x < 0 || y < 0 || x == grid.Length || y == grid[0].Length || grid[x][y] == 2 || grid[x][y] == 0) continue;
                        grid[x][y] = 2;
                        rotten.Enqueue(new int[] { x, y });
                        fresh--;
                    }
                }

            }

            if (fresh > 0) return -1;
            return minutes - 1;
        }
    }
}

