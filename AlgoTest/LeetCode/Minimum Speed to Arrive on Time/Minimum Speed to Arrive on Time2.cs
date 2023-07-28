using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Speed_to_Arrive_on_Time
{
    internal class Minimum_Speed_to_Arrive_on_Time2
    {
        public int MinSpeedOnTime(int[] dist, double hour)
        {
            var low = 1;
            var high = (int)Math.Pow(10, 7);
            var result = -1;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (MSOT(mid, dist, hour))
                {
                    result = mid;
                    high = mid - 1;
                }
                else low = mid + 1;
            }

            return result;
        }

        private bool MSOT(int speed, int[] dist, double hour)
        {
            double time = 0;
            for (var i = 0; i < dist.Length - 1; i++)
                time += Math.Ceiling((double)dist[i] / speed);
            
            time += (double)dist[^1] / speed;
            return time <= hour;
        }
    }
}
