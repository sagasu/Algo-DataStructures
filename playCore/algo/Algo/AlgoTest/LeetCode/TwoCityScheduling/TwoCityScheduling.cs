using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.TwoCityScheduling
{
    class TwoCityScheduling
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            var sum = 0;
            foreach (var cost in costs)
            {
                sum += Math.Min(cost[0], cost[1]);
            }

            return sum;
        }
    }
}
