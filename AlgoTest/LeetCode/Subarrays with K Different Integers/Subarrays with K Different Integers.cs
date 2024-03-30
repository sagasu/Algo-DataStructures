using System.Collections.Generic;

namespace AlgoTest.LeetCode.Subarrays_with_K_Different_Integers;

public class Subarrays_with_K_Different_Integers
{
    public int SubarraysWithKDistinct(int[] nums, int k) => AtMostKDistinct(nums, k) - AtMostKDistinct(nums, k - 1);
    
    private int AtMostKDistinct(int[] nums, int k) {
        var count = 0;
        var frequencyMap = new Dictionary<int, int>();
        var left = 0;
        
        for (var right = 0; right < nums.Length; right++) {
            var num = nums[right];
            if (!frequencyMap.ContainsKey(num))
                frequencyMap[num] = 0;
            frequencyMap[num]++;
            
            while (frequencyMap.Count > k) {
                frequencyMap[nums[left]]--;
                if (frequencyMap[nums[left]] == 0)
                    frequencyMap.Remove(nums[left]);
                left++;
            }
            
            count += right - left + 1;
        }
        
        return count;
    }
}