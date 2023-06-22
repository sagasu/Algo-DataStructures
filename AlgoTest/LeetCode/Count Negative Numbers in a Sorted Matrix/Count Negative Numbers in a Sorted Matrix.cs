using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_Negative_Numbers_in_a_Sorted_Matrix
{
    internal class Count_Negative_Numbers_in_a_Sorted_Matrix
    {
        public int CountNegatives(int[][] grid)
        {
            var count = 0;

            foreach (var arr in grid)
            foreach (var i in arr)
                if (i < 0)
                    count++;

            return count;
        }
    }
}
