using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Triangle
{
    internal class TriangleDifferentSolution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var length = triangle.Count() + 1;
            var myArray = new int[length];


            for (var i = triangle.Count() - 1; i >= 0; i--)
            for (var j = 0; j <= triangle[i].Count() - 1; j++)
                myArray[j] = triangle[i][j] + Math.Min(myArray[j], myArray[j + 1]);
                
            
            return myArray[0];
        }
    }
}
