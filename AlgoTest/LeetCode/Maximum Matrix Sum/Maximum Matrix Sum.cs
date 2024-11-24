using System;

namespace AlgoTest.LeetCode.Maximum_Matrix_Sum;

public class Maximum_Matrix_Sum
{
    public long MaxMatrixSum(int[][] matrix) 
    {
        long result = 0;
        long min = int.MaxValue;
        var negativeCount = 0;

        foreach (var t in matrix)
        {
            for(int j = 0; j < matrix[0].Length; ++j)
            {
                result += Math.Abs(t[j]);
                min = Math.Min(min, Math.Abs(t[j]));
                if(t[j] < 0)
                    negativeCount++;
            }
        }

        return negativeCount % 2 == 0 ? result : result - 2*min;
    }
}