using System.Collections.Generic;

namespace AlgoTest.LeetCode.Partition_Array_According_to_Given_Pivot;

public class Partition_Array_According_to_Given_Pivot
{
    public int[] PivotArray(int[] nums, int pivot) {
        List<int> less = new(), high = new(), result = new(new int[nums.Length]);
        var count = 0;

        foreach (var num in nums) {
            if (num < pivot) less.Add(num);
            else if (num == pivot) count++;
            else high.Add(num);
        }

        int index = 0;
        foreach (int num in less) result[index++] = num;
        for (int i = 0; i < count; i++) result[index++] = pivot;
        foreach (int num in high) result[index++] = num;

        return result.ToArray();
    }
}