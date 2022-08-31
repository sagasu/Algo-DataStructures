using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Pacific_Atlantic_Water_Flow
{
    internal class Pacific_Atlantic_Water_Flow
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var m = heights.Length;
            var n = heights[0].Length;
            var pacificCoast = new Queue<(int, int, int)>();
            var atlanticCoast = new Queue<(int, int, int)>();
            for (var k = 0; k < Math.Max(m, n); k++)
            {
                pacificCoast.Enqueue((0, k, 0));
                pacificCoast.Enqueue((k, 0, 0));
            }
            for (var k = 0; k < Math.Max(m, n); k++)
            {
                atlanticCoast.Enqueue((m - 1, k, 0));
                atlanticCoast.Enqueue((k, n - 1, 0));
            }
            var pacificFlow = Helper(heights, pacificCoast);
            var atlanticFlow = Helper(heights, atlanticCoast);
            return pacificFlow.Intersect(atlanticFlow).Select(t => new List<int> { t.Item1, t.Item2 }).Cast<IList<int>>().ToList();
        }

        HashSet<(int, int)> Helper(int[][] heights, Queue<(int, int, int)> queue)
        {
            var res = new HashSet<(int, int)>();
            while (queue.Any())
            {
                var (i, j, prev) = queue.Dequeue();
                if (i >= 0 && j >= 0 && i < heights.Length && j < heights[0].Length && !res.Contains((i, j)) && heights[i][j] >= prev)
                {
                    res.Add((i, j));
                    queue.Enqueue((i, j - 1, heights[i][j]));
                    queue.Enqueue((i, j + 1, heights[i][j]));
                    queue.Enqueue((i - 1, j, heights[i][j]));
                    queue.Enqueue((i + 1, j, heights[i][j]));
                }
            }
            return res;
        }
    }
}
