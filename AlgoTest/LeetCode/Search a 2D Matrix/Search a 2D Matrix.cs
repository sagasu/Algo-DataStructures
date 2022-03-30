using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Search_a_2D_Matrix
{
    internal class Search_a_2D_Matrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0, j = 0; i < matrix.Length && j < matrix[0].Length;)
            {
                if (matrix[i][j] == target) return true;

                if (matrix[i][j] > target) return false;

                if (matrix[i][matrix[i].Length - 1] < target) i++;
                else j++;
            }

            return false;
        }
    }
}
