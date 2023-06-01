using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Shortest_Path_in_Binary_Matrix
{
    [TestClass]
    public class Shortest_Path_in_Binary_MatrixSolution
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(2, ShortestPathBinaryMatrix(new int[][]{ new []{0,1}, new []{1,0}}));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual(4, ShortestPathBinaryMatrix(new int[][]{ new []{0,0,0}, new []{1,1,0}, new[] { 1, 1, 0 } }));
        
        [TestMethod]
        public void Test3() => Assert.AreEqual(-1, ShortestPathBinaryMatrix(new int[][]{ new []{1,0,0}, new []{1,1,0}, new[] { 1, 1, 0 } }));
        

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid[0][0] == 1) return -1;

            var queue = new Queue<(int,int,int)>();
            queue.Enqueue((0, 0,1));
            var matrix = new int[grid.Length, grid[0].Length];
            var directions = new[] { (1, 0), (1, 1), (0, 1), (-1, 0), (-1, -1), (0, -1), (1, -1), (-1, 1) };
            var minDistance = int.MaxValue;
            var finishX = grid.Length - 1;
            var finishY = grid[0].Length - 1;
            while (queue.Count > 0)
            {
                var (x,y,d) = queue.Dequeue();
                if (x == finishX && y == finishY)
                {
                    minDistance = Math.Min(minDistance, d);
                    continue;
                }

                if (matrix[x,y] != 0 && d >= matrix[x, y]) continue;

                foreach (var (xd, yd) in directions)
                {
                    var mx = x + xd;
                    var my = y + yd;
                    if (mx >= 0 && my >= 0 && mx <= finishX && my <= finishY && grid[mx][my] == 0)
                        queue.Enqueue((mx, my, d+1));
                    

                }
                matrix[x, y] = d;
            }

            return minDistance == int.MaxValue ? -1 : minDistance;
        }
    }
}
