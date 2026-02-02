using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

public class Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II
{
    public long MinimumCost(int[] nums, int k, int dist) {
        int n = nums.Length;
        int need = k - 1;

        var small = new SortedSet<(int val, int idx)>();
        var large = new SortedSet<(int val, int idx)>();
        long smallSum = 0;
        long ans = long.MaxValue;

        void Add((int val, int idx) x)
        {
            small.Add(x);
            smallSum += x.val;

            if (small.Count > need)
            {
                var maxSmall = small.Max;
                small.Remove(maxSmall);
                smallSum -= maxSmall.val;
                large.Add(maxSmall);
            }
        }

        void Remove((int val, int idx) x)
        {
            if (small.Remove(x))
            {
                smallSum -= x.val;
                if (large.Count > 0)
                {
                    var minLarge = large.Min;
                    large.Remove(minLarge);
                    small.Add(minLarge);
                    smallSum += minLarge.val;
                }
            }
            else
                large.Remove(x);
        }

        for (int i = 1; i <= dist + 1 && i < n; i++)
        {
            Add((nums[i], i));
        }

        if (small.Count == need)
            ans = smallSum;

        for (int l = 1, r = dist + 2; r < n; l++, r++)
        {
            Remove((nums[l], l));
            Add((nums[r], r));
            if (small.Count == need)
                ans = Math.Min(ans, smallSum);
        }

        return nums[0] + ans;
    }
}