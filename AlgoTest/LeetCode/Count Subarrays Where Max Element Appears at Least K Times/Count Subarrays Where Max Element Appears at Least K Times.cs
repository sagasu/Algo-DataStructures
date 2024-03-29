using System.Linq;

namespace AlgoTest.LeetCode.Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times;

public class Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times
{
    public long CountSubarrays(int[] nums, int k) {
        var maxElement = nums.Max();
        long count = 0;
        var windowStart = 0;
        var maxCount = 0;

        foreach (var t in nums)
        {
            if (t == maxElement) {
                maxCount++;
            }

            while (maxCount >= k) {
                if (nums[windowStart] == maxElement) {
                    maxCount--;
                }
                windowStart++;
            }

            count += windowStart;
        }

        return count;
    }
}