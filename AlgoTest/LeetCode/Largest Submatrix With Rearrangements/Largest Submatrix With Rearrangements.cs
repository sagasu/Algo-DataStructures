using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Largest_Submatrix_With_Rearrangements;

[TestClass]
public class Largest_Submatrix_With_Rearrangements
{
    [TestMethod]
    public void Test() => Assert.AreEqual(4, LargestSubmatrix(new int[][]
    {
        new int[]{0,0,1},
        new int[]{1,1,1},
        new int[]{1,0,1}
    }));
    
    public int LargestSubmatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var ans = 0;

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
                if (matrix[row][col] != 0 && row > 0)
                    matrix[row][col] += matrix[row - 1][col];

            var currRow = new int[matrix[row].Length];
            Array.Copy(matrix[row], currRow, matrix[row].Length);
            Array.Sort(currRow);
            for (var i = 0; i < n; i++)
                ans = Math.Max(ans, currRow[i] * (n - i));
        }

        return ans;
    }
}