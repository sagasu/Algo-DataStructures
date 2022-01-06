using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.CarPooling
{
    [TestClass]
    public class CarPoolingSolutionNicer
    {
        [TestMethod]
        public void Test()
        {
            var t = new[] {new[] {3, 2, 7}, new[] {3, 7, 9}, new[] {8, 3, 9}};
            Assert.IsTrue(CarPooling(t,11));
        }

        public bool CarPooling(int[][] trips, int capacity)
        {
            var path = new int[1001];
            foreach (var trip in trips)
                for (var i = trip[1]+1; i <= trip[2]; i++)
                    path[i] += trip[0];
              

            var max = 0;
            foreach (var kilometerDetails in path)
                max = Math.Max(kilometerDetails, max);
            
            return max <= capacity;
        }
    }
}
