using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.UniqueBinarySearchTrees
{
    public class UniqueBinarySearchTrees
    {
        public int NumTrees(int n)
        {
            long c = 1;
            for (var i = 0; i < n; ++i)
            {
                //Catalan number
                c = c * 2 * (2 * i + 1) / (i + 2);
            }
            return (int)c;
        }
    }
}
