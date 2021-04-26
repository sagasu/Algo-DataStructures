using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Furthest_Building_You_Can_Reach
{
    // This problem assums that ladder is for moving 1 up, and can only be used to move 1 up
    [TestClass]
    public class Furthest_Building_You_Can_Reach_DifferentProblem
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {4, 2, 7, 6, 9, 14, 12};
            Assert.AreEqual(4, FurthestBuilding(t, 5, 1));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 };
            Assert.AreEqual(7, FurthestBuilding(t, 10, 2));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 14, 3, 19, 3 };
            Assert.AreEqual(3, FurthestBuilding(t, 17, 0));
        }
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            for (var i = 1; i < heights.Length; i++)
            {
                var diff = heights[i] - heights[i - 1];
                if (diff == 1)
                {
                    if (ladders > 0)
                    {
                        ladders -= 1;
                        continue;
                    }
                    
                    if (bricks > 0)
                    {
                        bricks -= 1;
                        continue;
                    }

                    return i;
                }
                
                if (diff > 1)
                {
                    if (bricks >= diff)
                    {
                        bricks -= diff;
                        continue;
                    }

                    return i;
                }
                
            }

            return heights.Length - 1;

        }
    }
}
