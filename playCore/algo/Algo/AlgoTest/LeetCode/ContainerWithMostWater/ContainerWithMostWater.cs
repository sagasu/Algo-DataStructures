using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ContainerWithMostWater
{
    class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            var i = 0;
            var j = height.Length -1;
            var max = int.MinValue;
            while (i < j)
            {
                var min = Math.Min(height[i], height[j]);
                max = Math.Max(max, min * (j-i));
                if (min == height[i])
                    i++;
                else
                    j--;
            }

            return max;
        }
    }
}
