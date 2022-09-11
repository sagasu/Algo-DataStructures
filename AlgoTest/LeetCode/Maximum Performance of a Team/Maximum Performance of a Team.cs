using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Performance_of_a_Team
{
    internal class Maximum_Performance_of_a_Team
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            var mod = 1000000007;
            Array.Sort(efficiency, speed);
            var pq = new PriorityQueue<int, int>();
            long ans = 0, sum = 0;
            for (var i = n - 1; i >= 0; i--)
            {
                if (pq.Count >= k) sum -= pq.Dequeue();
                sum += speed[i];
                pq.Enqueue(speed[i], speed[i]);
                ans = Math.Max(ans, sum * efficiency[i]);
            }

            return (int)(ans % mod);
        }
    }
}
