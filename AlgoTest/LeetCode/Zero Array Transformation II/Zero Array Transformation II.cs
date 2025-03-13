using System;

namespace AlgoTest.LeetCode.Zero_Array_Transformation_II;

public class Zero_Array_Transformation_II
{
    public int MinZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] counts = new int[n + 1];
        int k = 0, sum = 0;

        for (int i = 0; i < n; i++) {
            int num = nums[i];
            while (sum + counts[i] < num) {
                if (k == queries.Length) return -1;
                int left = queries[k][0], right = queries[k][1], value = queries[k][2];
                k++;

                if (right < i) continue;
                counts[Math.Max(left, i)] += value;
                counts[right + 1] -= value;
            }
            sum += counts[i];
        }
        return k;
    }
}