using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Total_Cost_to_Hire_K_Workers
{
    internal class Total_Cost_to_Hire_K_Workers
    {
        public long TotalCost(int[] costs, int k, int candidates)
        {
            var n = costs.Length;
            PriorityQueue<(int val, bool isLeft), double> pq = new();

            var lmax = candidates;
            var rmax = n - candidates - 1;
            var l = 0;
            var r = n - 1;

            long res = 0;

            for (var i = 0; i < k; i++)
            {
                while (l < lmax && l <= r)
                {
                    pq.Enqueue((costs[l], true), costs[l]);
                    l++;
                }
                while (r > rmax && l <= r)
                {
                    pq.Enqueue((costs[r], false), costs[r] + 0.1);
                    r--;
                }

                var val = pq.Dequeue();
                if (val.isLeft) lmax++;
                else rmax--;
                
                res += val.val;
            }

            return res;
        }
    }
}
