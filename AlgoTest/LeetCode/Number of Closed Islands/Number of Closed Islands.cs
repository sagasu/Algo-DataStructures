using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Number_of_Closed_Islands
{
    [TestClass]
    public class Number_of_Closed_Islands
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][]
            {
                new []{1, 1, 1, 1, 1, 1, 1, 0},
                new []{1, 0, 0, 0, 0, 1, 1, 0},
                new []{1, 0, 1, 0, 1, 1, 1, 0},
                new []{1, 0, 0, 0, 0, 1, 0, 1},
                new []{1, 1, 1, 1, 1, 1, 1, 0}
            };
            Assert.AreEqual(2, ClosedIsland(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[][]
            {
                new []{1, 0, 1, 1, 1, 1, 0, 0, 1, 0},
                new []{1, 0, 1, 1, 0, 0, 0, 1, 1, 1},
                new []{0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
                new []{1, 0, 1, 1, 0, 1, 0, 0, 1, 0},
                new []{0, 1, 1, 1, 0, 1, 0, 1, 0, 0},
                new []{1, 0, 0, 1, 0, 0, 1, 0, 0, 0},
                new []{1, 0, 1, 1, 1, 0, 0, 1, 1, 0},
                new []{1, 1, 0, 1, 1, 0, 1, 0, 1, 1},
                new []{0, 0, 1, 1, 1, 0, 1, 0, 1, 1},
                new []{1, 0, 0, 1, 1, 1, 1, 0, 1, 1}
            };
            Assert.AreEqual(3, ClosedIsland(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[][]
            {
                new []{0,0,1,0,0},new []{0, 1, 0, 1, 0},new []{0, 1, 1, 1, 0}
            };
            Assert.AreEqual(1, ClosedIsland(t));
        }

        public int ClosedIsland(int[][] grid)
        {
            var nrOfClosedIslands = 0;
            var ni =grid.Length-1;
            var nj = grid[0].Length-1;

            bool IsClosedIsland(int i, int j)
            {
                if (i == 0 || i == ni) return grid[i][j] == 1;
                if (j == 0 || j == nj) return grid[i][j] == 1;

                var isClosed = true;

                if (grid[i - 1][j] == 0)
                {
                    grid[i - 1][j] = 3;
                    isClosed = IsClosedIsland(i - 1, j);
                }

                if (grid[i + 1][j] == 0)
                {
                    grid[i + 1][j] = 3;
                    isClosed = IsClosedIsland(i + 1, j) && isClosed;
                }

                if (grid[i][j - 1] == 0)
                {
                    grid[i][j - 1] = 3;
                    isClosed = IsClosedIsland(i, j-1) && isClosed;
                }

                if (grid[i][j + 1] == 0)
                {
                    grid[i][j + 1] = 3;
                    isClosed = IsClosedIsland(i, j+1) && isClosed;
                }
                
                return isClosed;
            }

            
            for (int i = 1; i < ni; i++)
            for (int j = 1; j < nj; j++)
                if (grid[i][j] == 0 && IsClosedIsland(i, j)) nrOfClosedIslands++;
                
            

            return nrOfClosedIslands;
        }
    }
}
