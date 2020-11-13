using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MergeIntervals
{
    [TestClass]
    public class MergeIntervals
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new[] {1, 4}, new[] {0, 4}};
            Merge(t);
        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length < 1)
                return intervals;
            var sorted = intervals.OrderBy(x => x[0]).ToArray();

            var res = new List<int[]>();
            res.Add(new int[]{ sorted[0][0], sorted[0][1] });
            var index = 0;
            for (var i = 1; i < sorted.Length; i++)
            {
                if (res[index][1] >= sorted[i][0] && res[index][1] <= sorted[i][1])
                {
                    res[index][1] = sorted[i][1];
                }else if (res[index][0] == sorted[i][0])
                {
                    res[index][1] = Math.Max(res[index][1], sorted[i][1]);
                }else if (res[index][1] > sorted[i][1])
                {
                    continue;
                }
                else
                {
                    index += 1;
                    res.Add(sorted[i]);
                }
            }

            return res.ToArray();
        }
    }
}
