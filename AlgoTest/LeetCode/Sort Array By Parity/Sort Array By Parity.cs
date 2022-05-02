using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Sort_Array_By_Parity
{
    internal class Sort_Array_By_Parity
    {
        public int[] SortArrayByParity(int[] A)
        {
            var sorted = new List<int>();

            foreach (var i in A)
            {
                if (i % 2 == 0) sorted.Insert(0, i);
                else sorted.Add(i);
            }

            return sorted.ToArray();
        }
    }
}
