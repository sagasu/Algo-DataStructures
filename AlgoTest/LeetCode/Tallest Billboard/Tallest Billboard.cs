using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Tallest_Billboard
{
    internal class Tallest_Billboard
    {
        public int TallestBillboard(int[] rods)
        {
            var d = new Dictionary<int, int>() { [0] = 0 };

            foreach (var rod in rods)
            {
                var next = d.ToDictionary(x => x.Key, x => x.Value);

                foreach (var kvp in d.ToList())
                {
                    next[kvp.Key + rod] = Math.Max(next.GetValueOrDefault(kvp.Key + rod), kvp.Value + rod);
                    next[kvp.Key - rod] = Math.Max(next.GetValueOrDefault(kvp.Key - rod), kvp.Value + rod);
                }

                d = next;
            }
            return d[0] / 2;
        }
    }
}
