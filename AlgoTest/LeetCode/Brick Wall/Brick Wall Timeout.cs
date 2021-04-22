using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Brick_Wall
{
    [TestClass]
    // Solution Times out 
    public class Brick_Wall_Timeout
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

        public int LeastBricks(IList<IList<int>> wall)
        {
            //index of next, current_sum
            var helper = new int[wall.Count, 2];
            var lineIndex = 0;
            var minSum = int.MaxValue;

            var width = wall[0].Sum(x => x);
            if (width == 1) return wall.Count;

            while (lineIndex < width)
            {
                lineIndex += 1;
                if (lineIndex == width) break;
                var sum = 0;
                for (var i = 0; i < wall.Count; i++)
                {
                    var nextIndex = helper[i, 0];
                    var currentSum = helper[i, 1];

                    if (nextIndex == wall[i].Count) continue;

                    if (currentSum + wall[i][nextIndex] == lineIndex)
                    {
                        helper[i, 0] += 1;
                        helper[i, 1] += wall[i][nextIndex];
                    }
                    else
                    {
                        sum += 1;
                    }
                }

                minSum = Math.Min(minSum, sum);

            }

            return minSum;
        }
    }
}
