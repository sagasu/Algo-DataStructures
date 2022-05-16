using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Shortest_Path_in_Binary_Matrix
{
    internal class Shortest_Path_in_Binary_Matrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            var N = grid.Length;
            if (grid[0][0] == 1 || grid[N - 1][N - 1] == 1) return -1;
            var res = 1;
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            while (queue.Count > 0)
            {
                var levelsize = queue.Count;
                for (var i = 0; i < levelsize; i++)
                {
                    var cur = queue.Dequeue();
                    var r = cur[0];
                    var c = cur[1];
                    if (r == N - 1 && c == N - 1) return res;

                    if (Valid(r - 1, c - 1, N, grid)) queue.Enqueue(new int[] { r - 1, c - 1 });
                    if (Valid(r - 1, c, N, grid)) queue.Enqueue(new int[] { r - 1, c });
                    if (Valid(r, c - 1, N, grid)) queue.Enqueue(new int[] { r, c - 1 });
                    if (Valid(r + 1, c + 1, N, grid)) queue.Enqueue(new int[] { r + 1, c + 1 });
                    if (Valid(r + 1, c, N, grid)) queue.Enqueue(new int[] { r + 1, c });
                    if (Valid(r, c + 1, N, grid)) queue.Enqueue(new int[] { r, c + 1 });
                    if (Valid(r + 1, c - 1, N, grid)) queue.Enqueue(new int[] { r + 1, c - 1 });
                    if (Valid(r - 1, c + 1, N, grid)) queue.Enqueue(new int[] { r - 1, c + 1 });
                }
                res++;
            }
            return -1;
        }

        public bool Valid(int r, int c, int N, int[][] grid)
        {
            if (!(r >= 0 && r < N && c >= 0 && c < N)) return false;
            if (grid[r][c] == 1) return false;

            grid[r][c] = 1;

            return true;
        }
    }
}
