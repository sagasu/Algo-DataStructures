using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Rectangle_Area_II
{
    class Rectangle_Area_II
    {
        public int RectangleArea(int[][] rectangles)
        {
            var lists = new List<int[]>();
            foreach (var rec in rectangles) update(lists, rec, 0);
            long res = 0, M = 1_000_000_007;
            foreach (var rec in lists) res = (res + area(rec[0], rec[1], rec[2], rec[3])) % M;
            return (int)res;
        }

        private long area(int x1, int y1, int x2, int y2)
        {
            return (x2 - x1) * (long)(y2 - y1);
        }

        private void update(List<int[]> lists, int[] a, int idx)
        {
            if (idx >= lists.Count)
            {
                lists.Add(a);
                return;
            }
            int[] b = lists[idx++];
            int l = Math.Max(a[0], b[0]), d = Math.Max(a[1], b[1]), r = Math.Min(a[2], b[2]), u = Math.Min(a[3], b[3]);
            if (l >= r || d >= u)
            {
                update(lists, a, idx);
                return;
            }
            if (a[0] < b[0]) update(lists, new int[] { a[0], a[1], b[0], a[3] }, idx);
            if (a[2] > b[2]) update(lists, new int[] { b[2], a[1], a[2], a[3] }, idx);
            if (a[1] < b[1]) update(lists, new int[] { l, a[1], r, b[1] }, idx);
            if (a[3] > b[3]) update(lists, new int[] { l, b[3], r, a[3] }, idx);
        }
    }
}
