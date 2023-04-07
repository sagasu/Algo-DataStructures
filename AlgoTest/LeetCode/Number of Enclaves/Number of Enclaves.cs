using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Enclaves
{
    public class Number_of_Enclaves
    {
        public int NumEnclaves(int[][] grid)
        {
            var ni = grid.Length-1;
            var nj = grid[0].Length-1;
            var nrOfEnclaves = 0;

            bool IsEnclave(int i, int j)
            {

            }

            for(var i =1;i<ni;i++)
                for(var j = 1;j<nj;j++)
                    if (grid[i][j] == 1 && IsEnclave(i,j)) nrOfEnclaves++;

            return nrOfEnclaves;
        }
    }
}
