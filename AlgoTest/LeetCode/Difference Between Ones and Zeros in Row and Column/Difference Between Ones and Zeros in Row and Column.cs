using System;

namespace AlgoTest.LeetCode.Difference_Between_Ones_and_Zeros_in_Row_and_Column;

public class Difference_Between_Ones_and_Zeros_in_Row_and_Column
{
    public int[][] OnesMinusZeros(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;

        var onesRow = new int[m];
        var onesCol = new int[n];

        Array.Fill(onesRow, 0);
        Array.Fill(onesCol, 0);

        for (var i = 0; i < m; i++) {
            for (var j = 0; j < n; j++) {
                onesRow[i] += grid[i][j];
                onesCol[j] += grid[i][j];
            }
        }

        var diff = new int[m][];

        for (var i = 0; i< diff.Length;i++)
            diff[i] = new int[n];
        
        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                diff[i][j] = 2 * onesRow[i] + 2 * onesCol[j] - n - m;

        return diff;
    }
}