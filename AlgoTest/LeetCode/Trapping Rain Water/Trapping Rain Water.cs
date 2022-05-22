using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Trapping_Rain_Water
{
    internal class Trapping_Rain_Water
    {
        public int Trap(int[] heights)
        {
            var n = heights.Length;
            if (n == 0) return 0;

            var water = 0;
            var seaLevel = 0;

            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                seaLevel = Math.Max(seaLevel, Math.Min(heights[left], heights[right]));

                water += Math.Max(0, seaLevel - heights[left]) + Math.Max(0, seaLevel - heights[right]);

                if (heights[left] > heights[right]) right--;
                else left++;
            }

            return water;
        }
    }
}
