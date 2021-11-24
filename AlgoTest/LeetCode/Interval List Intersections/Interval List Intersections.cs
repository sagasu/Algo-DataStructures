using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Interval_List_Intersections
{
    class Interval_List_Intersections
    {
        public int[][] IntervalIntersection(int[][] a, int[][] b)
        {
            IList<int[]> res = new List<int[]>();

            var i = 0;
            var j = 0;

            while (i != a.Length && j != b.Length)
            {
                var intervalA = a[i];
                var intervalB = b[j];

                if (intervalB[0] > intervalA[1]) {
                    i++;
                    continue;
                }

                if (intervalB[1] < intervalA[0]) {
                    j++;
                    continue;
                }

                res.Add(new int[] {
                    Math.Max(intervalA[0], intervalB[0]),
                    Math.Min(intervalA[1], intervalB[1])
                });

                if (intervalA[1] < intervalB[1]) i++;
                else j++;
            }

            return res.ToArray();
        }
    }
}
