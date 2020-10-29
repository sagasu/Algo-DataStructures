using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MaximizeDistancetoClosestPerson
{
    [TestClass]
    public class MaximizeDistancetoClosestPerson
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 0, 0, 0, 1, 0, 1};
            Assert.AreEqual(2, MaxDistToClosest(t));

            t = new int[] { 1, 0, 0, 0 };
            Assert.AreEqual(3, MaxDistToClosest(t));

            t = new int[] { 0, 1 };
            Assert.AreEqual(1, MaxDistToClosest(t));

        }

        public int MaxDistToClosest(int[] seats)
        {
            var n = seats.Length;
            var previous = -1;
            var maxDistance = 0;
            for (var i = 0; i < n; i++)
            {
                if (seats[i] == 1)
                {
                    maxDistance = previous == -1 ? i : Math.Max(maxDistance, (i - previous) / 2);
                    previous = i;
                }
            }

            maxDistance = Math.Max(maxDistance, n -1 - previous);
            return maxDistance;
        }
    }
}
