using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Submatrices_That_Sum_to_Target
{
    internal class Number_of_Submatrices_That_Sum_to_Target
    {
        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;

            var res = 0;
            for (var i = 0; i < m; i++)
            for (var j = 1; j < n; j++)
                    matrix[i][j] += matrix[i][j - 1];
            
            var counter = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
            for (var j = i; j < n; j++)
            {
                    counter.Clear();
                    counter[0] = 1;
                    var cur = 0;
                    for (var k = 0; k < m; k++)
                    {
                        cur += matrix[k][j] - (i > 0 ? matrix[k][i - 1] : 0);
                        if (counter.ContainsKey(cur - target)) res += counter[cur - target];
                        
                        if (counter.ContainsKey(cur)) counter[cur]++;
                        else counter[cur] = 1;
                    }
            }
            
            return res;
        }
    }
}
