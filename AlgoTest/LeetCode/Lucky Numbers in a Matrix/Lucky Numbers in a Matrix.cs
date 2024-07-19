using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Lucky_Numbers_in_a_Matrix;

public class Lucky_Numbers_in_a_Matrix
{
    public IList<int> LuckyNumbers (int[][] matrix) {
        List<int> result = new List<int>();
        int column = matrix.Length;
        int row = matrix[0].Length;

        int[] rowsMinIndexes = new int[column];
        for (int i = 0; i < column; i++)
        {
            int min = Int32.MaxValue;
            for (int j = 0; j < row; j++)
            {
                int val = matrix[i][j];
                if (val < min) 
                { 
                    rowsMinIndexes[i] = j;
                    min = val;
                }
            }
        }

        for (int i = 0; i < rowsMinIndexes.Length; i++)
        {
            int minIndex = rowsMinIndexes[i];
            int maxVal = matrix[i][minIndex];
            for (int j = 0; j < column; j++)
            {
                if (matrix[j][minIndex] >= maxVal)
                {
                    maxVal = matrix[j][minIndex];
                }
            }
            if (maxVal == matrix[i][minIndex]) { result.Add(maxVal); }
        }
        return result;
    }
}