using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_Odd_Numbers_in_an_Interval_Range
{
    internal class Count_Odd_Numbers_in_an_Interval_Range
    {
        public int CountOdds(int low, int high)
        {
            var count = 0;
            for (var i = low; i <= high; i++)
                if (i % 2 != 0) count += 1;
            
            return count;
        }
    }
}
