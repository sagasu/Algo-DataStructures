using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ValidSquare
{
    [TestClass]
    public class ValidSquareSolution
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(ValidSquare(new int[] {0, 0}, new int[] {0, 1}, new int[] { 1, 1 }, new int[] { 1, 0 }));
            Assert.IsTrue(ValidSquare(new int[] {-1, 0}, new int[] {0, 1}, new int[] { 1, 0 }, new int[] { 0, -1 }));
        }

        // points provided are nodes of a square, but the square can be rotated in a space.
        // so the idea is to realize that the distance between one node should be this same to it's 2 neighbors, as a following after sort distance between one fo these neighbors and it's neighbor. 
        // and the only distance that is different is the distance between two points that are most far away from each other, there are 2 such cases.
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var points = new int[][] {p1, p2, p3, p4};
            var distances = new List<int>();
            for (var i = 0; i < 4; i++)
            for (var j = i +1; j < 4; j++)
            {
                
                distances.Add(GetDistance(points[i], points[j]));
            }

            distances.Sort();

            return distances[0] > 0 && distances[0] == distances[1] && distances[0] == distances[2] && distances[0] == distances[3] && distances[4] == distances[5];
        }

        private int GetDistance(int[] point1, int[] point2)
        {
             var distance = Math.Pow(point1[0] - point2[0], 2) + Math.Pow(point1[1] - point2[1],2);
             return Convert.ToInt32(distance);
        }
    }
}
