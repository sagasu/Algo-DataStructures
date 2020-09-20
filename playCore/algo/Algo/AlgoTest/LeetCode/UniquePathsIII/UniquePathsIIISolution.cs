

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.UniquePathsIII
{
    [TestClass]
    public class UniquePathsIIISolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new[] {new[] {1, 0, 0, 0}, new[] {0, 0, 0, 0}, new[] {0, 0, 2, -1}};
            Assert.AreEqual(2,UniquePathsIII(t));
        }

        public int UniquePathsIII(int[][] grid)
        {
            var zeros = 0;
            var startX = 0;
            var startY = 0;
            for(var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0)
                {
                    zeros += 1;
                }else if (grid[i][j] == 1)
                {
                    startX = i;
                    startY = j;
                }
            }

            return DFS(grid, startX, startY, zeros);
        }

        private int DFS(int[][] grid, int x, int y, int zeros)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length || grid[x][y] == -1)
                return 0;

            if (grid[x][y] == 2)
                return zeros == -1 ? 1 : 0;

            grid[x][y] = -1;
            zeros -= 1;
            var countPaths = DFS(grid, x + 1, y, zeros) +
                             DFS(grid, x - 1, y, zeros) +
                             DFS(grid, x, y + 1, zeros) +
                             DFS(grid, x, y - 1, zeros);
            grid[x][y] = 0;
            zeros += 1;
            return countPaths;
        }
    }
}
