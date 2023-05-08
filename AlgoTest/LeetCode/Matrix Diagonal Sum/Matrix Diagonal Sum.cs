using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Matrix_Diagonal_Sum
{
    internal class Matrix_Diagonal_Sum
    {
        public int DiagonalSum(int[][] mat)
        {
            var n = mat.Length;
            var sum = 0;
            for (var i = 0; i < n; i++)
                sum += mat[i][i] + mat[i][n - i - 1];
            
            if (n % 2 == 1) sum -= mat[n / 2][n / 2];
            
            return sum;
        }
    }
}
