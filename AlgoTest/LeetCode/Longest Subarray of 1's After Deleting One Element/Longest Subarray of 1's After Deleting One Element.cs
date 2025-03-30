using System;

public class LongestSubarrayofAfterDeletingOneElement {
    public int LongestSubarray(int[] nums) {
        int li = 0, hi = 0, zero = 0, res = 0;
        while (hi < nums.Length) {
            zero += nums[hi] == 0 ? 1 : 0;
            while (zero > 1)
                zero -= nums[li++] == 0 ? 1 : 0;
            res = Math.Max(res, hi - li);
            hi++;
        }
        return res;
    }
}