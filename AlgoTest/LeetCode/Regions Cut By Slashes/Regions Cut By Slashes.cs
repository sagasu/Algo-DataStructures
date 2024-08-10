using System.Collections.Generic;

namespace AlgoTest.LeetCode.Regions_Cut_By_Slashes;

public class Regions_Cut_By_Slashes
{
    public int RegionsBySlashes(string[] sourceMap) {
        var map = ToBinaryMap(sourceMap);
        var maxRow = map.GetLength(0) - 1;
        var maxCol = map.GetLength(1) - 1;
        var count = 0;

        for (var row = 0; row <= maxRow; row++)
        for (var col = 0; col <= maxCol; col++)
            if (!map[row, col]) {
                Dfs(row, col);
                count++;
            }
        return count;

        void Dfs(int row, int col) {
            if (map[row, col]) return;

            map[row, col] = true;

            if (row > 0) Dfs(row - 1, col);
            if (col > 0) Dfs(row, col - 1);
            if (row < maxRow) Dfs(row + 1, col);
            if (col < maxCol) Dfs(row, col + 1);
        }
    }

    private static bool[,] ToBinaryMap(string[] source) {
        const bool O = false, T = true;
        var cellByChar = new Dictionary<char, bool[,]> {
            {' ',  new[,] {{O, O, O},
                {O, O, O},
                {O, O, O}}},

            {'/',  new[,] {{O, O, T},
                {O, T, O},
                {T, O, O}}},

            {'\\', new[,] {{T, O, O},
                {O, T, O},
                {O, O, T}}}
        };
        var grid = new bool[source.Length * 3, source[0].Length * 3];

        for (var row = 0; row < source.Length; row++)
        for (var col = 0; col < source[0].Length; col++) {
            var cell = cellByChar[source[row][col]];
            for (var r = 0; r < 3; r++)
            for (var c = 0; c < 3; c++)
                grid[row * 3 + r, col * 3 + c] = cell[r, c];
        }
        return grid;
    }
}