using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.MinCostPath
{
    [TestFixture]
    class MinCostPath2Tests
    {
        //[TestCase(new int[,]{{1,2,3},{1,2,3}}, 4)]
        //int[][] grid, int expectedMinCostPath
        [Test]
        public void GetMinCostPath_ValidGrid_MinCostPath()
        {
            var grid = new int[,] {{1, 2, 3}, {1, 2, 3}};
            int expectedMinCostPath = 6;

            Assert.AreEqual(expectedMinCostPath, new MinCostPath().GetMinCostPath(grid, grid.GetLength(0)-1, grid.GetLength(1) -1));
        }
    }
}
