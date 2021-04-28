using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Unique_Paths_II
{
    [TestClass]
    public class Unique_Paths_II
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {new int[] {0, 0, 0}, new int[] {0, 1, 0}, new int[] {0, 0, 0}};
            Assert.AreEqual(2,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[][] {new int[] { 0, 1 }, new int[] { 0, 0 }};
            Assert.AreEqual(1,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[][] {new int[] { 1 }};
            Assert.AreEqual(0,UniquePathsWithObstacles(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[][] {new int[] { 1,0 }};
            Assert.AreEqual(0,UniquePathsWithObstacles(t));
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var rows = obstacleGrid.Length;
            var cols = obstacleGrid[0].Length;
            var cache = new int?[rows,cols];

            int Count(int x, int y)
            {
                if (x >= rows || y >= cols) return 0;

                if (obstacleGrid[x][y] == 1) return 0;
                if (cache[x, y] != null) return cache[x, y].Value;

                if(x == rows -1 && y == cols -1) return 1;

                var ways = 0;
                ways += Count(x, y + 1);
                ways += Count(x + 1, y);
                cache[x, y] = ways;
                return ways;
            }

            return Count(0, 0);
        }
    }
}
