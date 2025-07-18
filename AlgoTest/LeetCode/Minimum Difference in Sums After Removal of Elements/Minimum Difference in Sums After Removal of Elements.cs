using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Difference_in_Sums_After_Removal_of_Elements;

public class Minimum_Difference_in_Sums_After_Removal_of_Elements
{
    public long MinimumDifference(int[] nums) {
        int n3 = nums.Length, n = n3 / 3;
        long[] part1 = new long[n + 1];
        long sum = 0;
        var ql = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < n; ++i)
        {
            sum += nums[i];
            ql.Enqueue(nums[i], nums[i]);
        }
        part1[0] = sum;
        for (int i = n; i < n * 2; ++i)
        {
            sum += nums[i];
            ql.Enqueue(nums[i], nums[i]);
            sum -= ql.Dequeue();
            part1[i - (n - 1)] = sum;
        }

        long part2 = 0;
        var qr = new PriorityQueue<int, int>();
        for (int i = n * 3 - 1; i >= n * 2; --i)
        {
            part2 += nums[i];
            qr.Enqueue(nums[i], nums[i]);
        }
        long ans = part1[n] - part2;
        for (int i = n * 2 - 1; i >= n; --i)
        {
            part2 += nums[i];
            qr.Enqueue(nums[i], nums[i]);
            part2 -= qr.Dequeue();
            ans = Math.Min(ans, part1[i - n] - part2);
        }
        return ans;
    }
}