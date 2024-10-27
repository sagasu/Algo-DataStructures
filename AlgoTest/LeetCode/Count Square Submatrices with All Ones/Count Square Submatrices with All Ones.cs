using System.Linq;

namespace AlgoTest.LeetCode.Count_Square_Submatrices_with_All_Ones;

public class Count_Square_Submatrices_with_All_Ones
{
    public int CountSquares(int[][] matrix)
    {
        var count = 0;
        for (var i = 0; i < matrix.Length; i++) {
            for (var j = 0; j < matrix[0].Length; j++) {
                var right = matrix[0].Length - j - 1;
                var left = matrix.Length - i - 1;
                var min = right < left ? right : left;
                for (var k = 1; k <= min + 1; k++) {
                    var allOnes = Enumerable.Range(0, k)
                        .SelectMany(x => Enumerable.Range(0, k).Select(y => matrix[i + x][j + y]))
                        .All(x => x == 1);
                    if (allOnes) count++; else break;
                }
            }
        }
        return count;
    }
}