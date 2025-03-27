using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Index_of_a_Valid_Split;

public class Minimum_Index_of_a_Valid_Split
{
    public int MinimumIndex(IList<int> nums) {
        var count = new Dictionary<int, int>();
        int dominantElement = -1;
        int dominantCount = 0;

        foreach (var num in nums) {
            if (!count.ContainsKey(num)) {
                count[num] = 0;
            }
            count[num]++;
            if (count[num] > dominantCount) {
                dominantCount = count[num];
                dominantElement = num;
            }
        }

        int currentCount = 0;
        int n = nums.Count;

        for (int i = 0; i < n - 1; i++) {
            if (nums[i] == dominantElement) {
                currentCount++;
            }

            int rightCount = dominantCount - currentCount;

            if (currentCount > (i + 1) / 2 && rightCount > (n - (i + 1)) / 2) {
                return i;
            }
        }

        return -1;
    }
}