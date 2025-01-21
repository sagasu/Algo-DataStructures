using System;
using System.Linq;

namespace AlgoTest.LeetCode.Grid_Game;

public class Grid_Game
{
    public long GridGame(int[][] grid) {
        var minResult = long.MaxValue;
        var row1Sum = grid[0].Aggregate<int, long>(0, (current, val) => current + val);

        long row2Sum = 0;

        for (var i = 0; i < grid[0].Length; ++i)
        {
            row1Sum -= grid[0][i];
            minResult = Math.Min(minResult, Math.Max(row1Sum, row2Sum));
            row2Sum += grid[1][i];
        }

        return minResult;
    }
}