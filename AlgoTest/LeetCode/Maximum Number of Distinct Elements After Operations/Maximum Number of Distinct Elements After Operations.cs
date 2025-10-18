using System;

namespace AlgoTest.LeetCode.Maximum_Number_of_Distinct_Elements_After_Operations;

public class Maximum_Number_of_Distinct_Elements_After_Operations
{
    public int MaxDistinctElements(int[] nums, int k) {
        Array.Sort(nums);
        long prevAssigned = long.MinValue / 4; // very small
        int distinctCount = 0;
        foreach (int v in nums) {
            long num = v;
            long assigned = Math.Max(num - k, prevAssigned + 1);
            if (assigned <= num + k) {
                distinctCount++;
                prevAssigned = assigned;
            }
        }
        return distinctCount;
    }
}