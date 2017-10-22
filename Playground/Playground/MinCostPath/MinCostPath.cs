using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.MinCostPath
{
    // In this implementation we allowed recursion to go outside the grid, and we just punish such path with ultra large pathcost
    class MinCostPath
    {
        public int GetMinCostPath(int[,] grid, int m, int n)
        {
            return GetMinCostPath(grid, m, n, 0, 0);
        }

        private int GetMinCostPath(int[,] grid, int m, int n, int row, int column)
        {
            if (row > m || column > n)
                return int.MaxValue; // we are ountside of grid, this path doesn't make sense

            if (m == row && n == column)
                return grid[row, column];

            var p1Cost = GetMinCostPath(grid, m, n, row + 1, column);
            var p2Cost = GetMinCostPath(grid, m, n, row + 1, column + 1);
            var p3Cost = GetMinCostPath(grid, m, n, row, column + 1);

            return grid[row, column] + Math.Min(p1Cost, Math.Min(p2Cost, p3Cost));
        }
    }
}
