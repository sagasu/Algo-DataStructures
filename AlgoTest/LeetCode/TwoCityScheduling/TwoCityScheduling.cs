using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.TwoCityScheduling
{
    [TestClass]
    public class TwoCityScheduling
    {
        [TestMethod]
        public void Test()
        {
            //var t = new int[][] {new[]{10, 20}, new[] { 30, 200}, new[] { 400, 50}, new[] { 30, 20}};
            var t = new int[][] {new[]{10, 20}, new[] { 30, 200}, new[] { 400, 50}, new[] { 30, 20}, new[] { 10, 20 }, new[] { 10, 20 } };
            TwoCitySchedCost(t);
        }

        public int TwoCitySchedCost(int[][] costs)
        {
            var sorted = costs.OrderByDescending(x => Math.Abs(x[0] - x[1]));

            var sum = 0;
            var fligthsToA = 0;
            var flightsToB = 0;
            var sumOfFlights = costs.Length / 2;
            foreach (var cost in sorted)
            {
                if (cost[0] < cost[1] && (fligthsToA < sumOfFlights) || flightsToB >= sumOfFlights)
                {
                    fligthsToA += 1;
                    sum += cost[0];
                }
                else
                {
                    flightsToB += 1;
                    sum += cost[1];
                }
                
            }

            return sum;
        }
    }
}
