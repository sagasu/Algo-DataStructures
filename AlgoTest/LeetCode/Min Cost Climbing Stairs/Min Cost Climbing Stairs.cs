using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Min_Cost_Climbing_Stairs
{
    internal class Min_Cost_Climbing_Stairs
    {
        public int MinCostClimbingStairs(int[] cost) => cost
            .Aggregate(
                new[] { 0, 0 },
                (arr, c) => new[] { arr[1], c + arr.Min() }
            )
            .Min();
    }
}
