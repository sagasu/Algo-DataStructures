using System;

namespace AlgoTest.LeetCode.Container_With_Most_Water;

internal class Container_With_Most_Water
{
    public int MaxArea(int[] h)
    {
        int start = 0, end = h.Length - 1, maxArea = 0;
        while (start < end)
        {
            maxArea = Math.Max(maxArea, Math.Min(h[start], h[end]) * (end - start));
            if (h[start] < h[end]) start++;
            else end--;
        }

        return maxArea;
    }
}