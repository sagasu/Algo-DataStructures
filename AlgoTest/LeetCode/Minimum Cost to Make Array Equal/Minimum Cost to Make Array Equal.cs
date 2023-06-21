using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Cost_to_Make_Array_Equal
{
    internal class Minimum_Cost_to_Make_Array_Equal
    {
        private static long Price(int[] nums, int[] cost, long value) => nums
            .Zip(cost, (n, c) => Math.Abs(n - value) * c)
            .Sum();

        public long MinCost(int[] nums, int[] cost)
        {
            var left = nums.Min();
            var right = nums.Max();

            while (right - left > 1)
            {
                var middle = (left + right) / 2;

                if (Price(nums, cost, middle) < Price(nums, cost, middle + 1))
                    right = middle;
                else
                    left = middle + 1;
            }

            return Math.Min(Price(nums, cost, left), Price(nums, cost, right));
        }
    }
}
