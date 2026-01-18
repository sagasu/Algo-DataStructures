using System;

namespace AlgoTest.LeetCode.Largest_Magic_Square;

public class Largest_Magic_Square
{
    public int LargestMagicSquare(int[][] grid) {
        int result = 1;
        bool found = false;
        int[][] rSum = new int[grid.Length][];
        int[][] cSum = new int[grid[0].Length][];
        for (int y = 0; y < grid.Length; y++) {
            rSum[y] = new int[grid[0].Length];
        }
        for (int x = 0; x < grid[0].Length; x++) {
            cSum[x] = new int[grid.Length];
        }
        for (int y = 0; y < grid.Length; y++) {
            for (int x = 0; x < grid[0].Length; x++) {
                rSum[y][x] = (x == 0 ? 0 : rSum[y][x - 1]) + grid[y][x];
                cSum[x][y] = (y == 0 ? 0 : cSum[x][y - 1]) + grid[y][x];
            }
        }
        var maxK = Math.Min(grid[0].Length, grid.Length);
        for (int k = maxK; !found && k > 1; k--) {
            for (int t = 0; !found && t + k <= grid.Length; t++) {
                for (int l = 0; !found && l + k <= grid[0].Length; l++) {
                    if (Check(grid, t, l, k, rSum, cSum)) {
                        found = true;
                        result = k;
                    }
                }
            }
        }
        return result;
    }

    static bool Check(int[][] grid, int t, int l, int k, int[][] rSum, int[][] cSum) {
        var b = t + k - 1;
        var r = l + k - 1;
        var s = rSum[t][r] - (l == 0 ? 0 : rSum[t][l - 1]);
        var d1 = 0;
        var d2 = 0;
        for (int ki = 0; ki < k; ki++) {
            var rs = rSum[t + ki][r] - (l == 0 ? 0 : rSum[t + ki][l - 1]);
            if (rs != s) {
                return false;
            }
            var cs = cSum[l + ki][b] - (t == 0 ? 0 : cSum[l + ki][t - 1]);
            if (cs != s) {
                return false;
            }
            d1 += grid[t + ki][l + ki];
            d2 += grid[t + ki][r - ki];
        }
        return d1 == s && d2 == s;
    }
}