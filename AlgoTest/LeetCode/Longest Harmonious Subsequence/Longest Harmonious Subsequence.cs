using System;

namespace AlgoTest.LeetCode.Longest_Harmonious_Subsequence;

public class Longest_Harmonious_Subsequence
{
    public int FindLHS(int[] nums) {
        Array.Sort(nums);
        int max = 0;
        int start = 0;
 
        for (int end = 0; end < nums.Length; end++) {
            while (nums[end] - nums[start] > 1) {
                start++;
            }
 
            if (nums[end] - nums[start] == 1) {
                int len = end - start + 1;
                if (len > max) {
                    max = len;
                }
            }
        }
 
        return max;
    }
}