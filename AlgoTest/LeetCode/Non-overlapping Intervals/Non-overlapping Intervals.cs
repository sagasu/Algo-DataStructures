using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Non_overlapping_Intervals
{
    internal class Non_overlapping_Intervals
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            Array.Sort(intervals, (x, y) => x[1].CompareTo(y[1]));
            var result = 0;
            var end = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
                if (intervals[i][0] >= end) end = intervals[i][1];
                else result++;

            return result;
        }
    }
}
