using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Kth_Smallest_Element_in_a_Sorted_Matrix_Prob
{
    internal class Kth_Smallest_Element_in_a_Sorted_Matrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            var pq = new PriorityQueue<int[], int>();
            for (var i = 0; i < matrix.Length; i++)
                pq.Enqueue(new int[] { i, 0 }, matrix[i][0]);
            
            var res = 0;
            for (var i = 0; i < k; i++)
            {
                var curr = pq.Dequeue();
                res = matrix[curr[0]][curr[1]];
                if (curr[1] + 1 < matrix[0].Length)
                    pq.Enqueue(new int[] { curr[0], curr[1] + 1 }, matrix[curr[0]][curr[1] + 1]);
                
            }
            return res;
        }
    }
}
