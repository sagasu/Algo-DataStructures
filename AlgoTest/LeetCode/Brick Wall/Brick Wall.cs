using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Brick_Wall
{
    [TestClass]
    public class Brick_Wall
    {
        [TestMethod]
        public void Test()
        {
            var t = new List<IList<int>>
            {
                new List<int>{1,2,2,1},
                new List<int>{3,1,2},
                new List<int>{1,3,2},
                new List<int>{2,4},
                new List<int>{3,1,2},
                new List<int>{1,3,1,1},
            };
            Assert.AreEqual(2, LeastBricks(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new List<IList<int>>
            {
                new List<int>{1},
                new List<int>{1},
                new List<int>{1},
            };
            Assert.AreEqual(3, LeastBricks(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new List<IList<int>>
            {
                new List<int>{100000000},
                new List<int>{100000000},
                new List<int>{100000000},
            };
            Assert.AreEqual(3, LeastBricks(t));
        }

        // Idea is to traverse it like a graph
        // find shortest path when 0 when there is no brick and 1 where there is a brick.
        // So we are moving a line (line position) per each brick and sum it per row for other rows that also have gap (or brick) on a given linePosition
        // And at the end selecting the line (counter) with shortest path - because it had smallest amounts of 1 (bricks)
        public int LeastBricks(IList<IList<int>> wall)
        {
            var counter = new Dictionary<int, int>();
            var rows = wall.Count;

            foreach (var row in wall)
            {
                var linePosition = 0;

                for (var i = 0; i < row.Count - 1; i++)
                {
                    linePosition += row[i];
                    if (!counter.TryAdd(linePosition, 1)) counter[linePosition] += 1;
                }
            }

            if (counter.Count == 0) return rows;


            return rows - counter.Values.Max();
        }
    }
}
