using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.IslandPerimeter
{
    public class IslandPerimeterProblem
    {
        public int IslandPerimeter(int[][] grid)
        {
            var per = 0;
            for (var row = 0; row < grid.Length; row++)
            {
                for (var column = 0; column < grid[0].Length; column++)
                {
                    if (grid[row][column] == 1)
                    {
                        per += CalcCellPerm(grid, row, column);
                    }
                }
            }

            return per;

        }

        private int CalcCellPerm(int[][] grid, int row, int column)
        {
            var per = 0;
            if (row == 0 || grid[row-1][column] == 0)
            {
                per += 1;
            }

            if (column == 0 || grid[row][column - 1] == 0)
            {
                per += 1;
            }

            if (column == grid[0].Length -1 || grid[row][column + 1] == 0)
            {
                per += 1;
            }

            if (row == grid.Length - 1 || grid[row+1][column] == 0)
            {
                per += 1;
            }

            return per;
        }
    }
}
