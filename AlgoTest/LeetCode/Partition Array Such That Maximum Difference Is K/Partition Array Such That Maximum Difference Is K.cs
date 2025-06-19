using System;

namespace AlgoTest.LeetCode.Partition_Array_Such_That_Maximum_Difference_Is_K;

public class Partition_Array_Such_That_Maximum_Difference_Is_K
{
    public int PartitionArray(int[] nums, int k) //* 2294. Partition Array Such That Maximum Difference Is K
    {
        int min = Int32.MaxValue,
            max = Int32.MinValue,
            length = nums.Length,
            count = 0;

        for (int i = 0; i < length; i++) //* Detect the "Min" and "Max" values.
        {
            int cur = nums[i];
            if (cur > max) max = cur;
            if (cur < min) min = cur;
        }

        Span<int> counter = stackalloc int[max - min + 1]; //* Initializing span.

        for (int i = 0; i < length; i++) //* Counting every value.
            counter[nums[i] - min]++;

        for (int i = 0; i < max - min + 1; i++) //* Check if there is a value in the "Counter" span, add +1 to count and skip the "i" index k times.
        {
            if (counter[i] > 0)
            {
                count++;
                i += k;
            }
        }
        
        return count;
    }
}