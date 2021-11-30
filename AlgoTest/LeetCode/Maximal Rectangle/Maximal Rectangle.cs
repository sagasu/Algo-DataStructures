using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Maximal_Rectangle
{
    class Maximal_Rectangle
    {
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length <= 0) return 0;

            var maxArea = 0;
            var dp = new int[matrix[0].Length];

            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix[i].Length; j++)
                if (matrix[i][j] != '0'){
                        var minHeight = int.MaxValue;
                        dp[j] += Convert.ToInt16(matrix[i][j] - '0');

                        for (var k = j; k >= 0 && matrix[i][k] > 0; k--)
                        {
                            minHeight = Math.Min(minHeight, dp[k]);
                            maxArea = Math.Max(maxArea, minHeight * (j - k + 1));
                        }
                }else dp[j] = 0;
    
            return maxArea;
        }
	}
}
