using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.NumberOfIslands
{
    class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            var count = 0;
            for(var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    count += 1;
                    RemoveIsland(grid, i, j);
                }
            }

            return count;
        }

        private void RemoveIsland(char[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length || grid[i][j] == '0')
                return;
            grid[i][j] = '0';
            RemoveIsland(grid, i+1, j);
            RemoveIsland(grid, i-1, j);
            RemoveIsland(grid, i, j+1);
            RemoveIsland(grid, i, j-1);
        }
    }
}
