using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Capacity_To_Ship_Packages_Within_D_Days
{
    internal class Capacity_To_Ship_Packages_Within_D_Days
    {
        public int ShipWithinDays(int[] weights, int days)
        {
            var left = weights.Max();
            var right = weights.Sum();
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (CanShip(mid, weights, days)) { right = mid; }
                else { left = mid + 1; }
            }
            return right;
        }

        bool CanShip(int capaCity, int[] weights, int days)
        {
            var daysNeeded = 1;
            var curWeights = 0;
            foreach (var w in weights)
            {
                curWeights += w;
                if (curWeights > capaCity)
                {
                    daysNeeded += 1;
                    curWeights = w;
                }
            }
            return daysNeeded <= days;
        }
    }
}
