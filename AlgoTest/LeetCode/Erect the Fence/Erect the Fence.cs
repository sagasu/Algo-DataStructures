using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Erect_the_Fence
{
    class Erect_the_Fence
    {
        public int Orientation(int[] p, int[] q, int[] r)
            => (q[1] - p[1]) * (r[0] - q[0]) - (q[0] - p[0]) * (r[1] - q[1]);

        public int[][] OuterTrees(int[][] trees)
        {
            Array.Sort(trees, (p, q) => q[0] - p[0] == 0 ? q[1] - p[1] : q[0] - p[0]);

            var hull = new Stack<int[]>();
            for (int i = 0; i < trees.Length; i++)
            {
                while (hull.Count >= 2 && Orientation(hull.ElementAt(1), hull.Peek(), trees[i]) > 0)
                    hull.Pop();
                hull.Push(trees[i]);
            }

            hull.Pop();

            for (int i = trees.Length - 1; i >= 0; i--)
            {
                while (hull.Count >= 2 && Orientation(hull.ElementAt(1), hull.Peek(), trees[i]) > 0)
                    hull.Pop();
                hull.Push(trees[i]);
            }

            var hashSet = new HashSet<int[]>(hull);
            return hashSet.ToArray();
        }
    }
}
