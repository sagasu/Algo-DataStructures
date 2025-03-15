using System;

namespace AlgoTest.LeetCode.House_Robber_IV;

public class House_Robber_IV
{
    public int MinCapability(int[] nums, int k) {
        int left = int.MaxValue, right = int.MinValue;

        foreach (int num in nums) {
            left = Math.Min(left, num);
            right = Math.Max(right, num);
        }

        while (left < right) {
            int mid = left + (right - left) / 2;
            if (CanRobAtLeastK(nums, k, mid)) {
                right = mid; 
            } else {
                left = mid + 1; 
            }
        }

        return left;
    }
    private bool CanRobAtLeastK(int[] nums, int k, int cap) {
        int count = 0;
        int i = 0;

        while (i < nums.Length) {
            if (nums[i] <= cap) {
                count++;
                i++; 
            }
            i++; 
        }

        return count >= k;
    }
}