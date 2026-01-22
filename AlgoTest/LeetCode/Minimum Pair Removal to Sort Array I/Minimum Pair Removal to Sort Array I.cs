using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Pair_Removal_to_Sort_Array_I;

public class Minimum_Pair_Removal_to_Sort_Array_I
{
    public int MinimumPairRemoval(int[] nums) {
        List<int> list = new(nums);
        int count = 0;

        while (true) {
            int idx = -1;
            int minSum = int.MaxValue;
            bool sorted = true;

            for (int i = 0; i < list.Count - 1; i++) {
                if (list[i] > list[i + 1])
                    sorted = false;

                int sum = list[i] + list[i + 1];
                if (sum < minSum) {
                    minSum = sum;
                    idx = i;
                }
            }

            if (sorted) break;

            list[idx] = minSum;
            list.RemoveAt(idx + 1);
            count++;
        }

        return count;
    }
}