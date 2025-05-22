using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Zero_Array_Transformation_III;

public class Zero_Array_Transformation_III
{
    public int MaxRemoval(int[] nums, int[][] queries) {
        Array.Sort(queries, (a, b) => a[0] - b[0]);
        var heap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a)));
        int[] deltaArray = new int[nums.Length + 1];
        int operations = 0;

        for (int i = 0, j = 0; i < nums.Length; i++) {
            operations += deltaArray[i];
            while (j < queries.Length && queries[j][0] == i) {
                heap.Enqueue(queries[j][1], queries[j][1]);
                j++;
            }
            while (operations < nums[i] && heap.Count > 0 && heap.Peek() >= i) {
                operations += 1;
                deltaArray[heap.Dequeue() + 1] -= 1;
            }
            if (operations < nums[i]) {
                return -1;
            }
        }
        return heap.Count;
    }
}