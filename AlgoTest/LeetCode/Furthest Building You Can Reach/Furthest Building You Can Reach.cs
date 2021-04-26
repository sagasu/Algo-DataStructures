using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Furthest_Building_You_Can_Reach
{
    [TestClass]
    //Timeout
    public class Furthest_Building_You_Can_Reach
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
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] { 1, 5, 1, 2, 3, 4, 10000 };
            Assert.AreEqual(5, FurthestBuilding(t, 4, 1));
        }

        HashSet<string> hashSet = new HashSet<string>();
        private string Hash(int index, int bricks, int ladders) => $"{index}_{bricks}_{ladders}";
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var max = int.MinValue;
            void dfs(int index, int bricksLeft, int laddersLeft)
            {
                if (hashSet.Contains(Hash(index, bricksLeft, laddersLeft))) return;

                if (index == heights.Length)
                {
                    max = Math.Max(max, heights.Length - 1);
                    hashSet.Add(Hash(index, bricksLeft, laddersLeft));
                    return;
                }

                var diff = heights[index] - heights[index - 1];
                if (diff > 0)
                {
                    var able = false;
                    if (bricksLeft >= diff)
                    {
                        dfs(index + 1, bricksLeft - diff, laddersLeft);
                        able = true;
                    }

                    if (laddersLeft > 0)
                    {
                        able = true;
                        dfs(index + 1, bricksLeft, laddersLeft - 1);
                    }
                    if(!able)
                    {
                        hashSet.Add(Hash(index, bricksLeft, laddersLeft));
                        max = Math.Max(max, index - 1);
                    }
                }
                else
                {
                    dfs(index + 1, bricksLeft, laddersLeft);
                }

                
            }

            dfs(1, bricks, ladders);
            return max;

        }
    }
}
