using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.MinCostPath
{
    // In this implementatnio it is illegal to go outside grid
    // So we verify before jumplig to the illegal location
    class MinCostPath2
    {
        public int GetMinCostPath(int[,] grid, int m, int n)
        {
            return GetMinCostPath(grid, m, n, 0, 0);
        }

        private int GetMinCostPath(int[,] grid, int m, int n, int row, int column)
        {
            if (m == row && n == column)
                return grid[row, column];

            var p3Cost = 0;
            if (row + 1 <= m)
            {
                var p1Cost = GetMinCostPath(grid, m, n, row + 1, column);

                if (column + 1 <= n)
                {
                    var p2Cost = GetMinCostPath(grid, m, n, row + 1, column + 1);
                    p3Cost = GetMinCostPath(grid, m, n, row, column + 1);
                    return grid[row, column] + Math.Min(p1Cost, Math.Min(p2Cost, p3Cost));
                }

                return grid[row, column] + p1Cost;
            }

            //this code only executes if (column + 1 <= n)
            p3Cost = GetMinCostPath(grid, m, n, row, column + 1);
            
            return grid[row, column] + p3Cost;
        }
    }
}
