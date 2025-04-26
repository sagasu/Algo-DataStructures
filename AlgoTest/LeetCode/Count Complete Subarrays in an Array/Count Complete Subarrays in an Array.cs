using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Complete_Subarrays_in_an_Array;

public class Count_Complete_Subarrays_in_an_Array
{
    public int CountCompleteSubarrays(int[] nums) {
        var n = nums.Length;
        var set = new HashSet<int>(nums);
        var distinct_elements = set.Count;
        var count = 0;
        var left = 0;
        var right = 0;
        var counter = new Dictionary<int, int>();

        while (right < n) {
            if (!counter.ContainsKey(nums[right])) {
                counter[nums[right]] = 0;
            }
            counter[nums[right]]++;
            while (counter.Count == distinct_elements) {
                counter[nums[left]]--;
                if (counter[nums[left]] == 0) {
                    counter.Remove(nums[left]);
                }
                left++;
                count += n - right;
            }
            right++;
        }
        return count;        
    }
}