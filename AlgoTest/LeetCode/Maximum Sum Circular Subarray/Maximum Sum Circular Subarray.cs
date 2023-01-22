public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int n = nums.Length;

        int max = nums[0];
        int current = nums[0];
        int[] sum = new int[n];
        sum[0] = current;
        int[] forward = new int[n];
        forward[0] = current;
        int[] reverse = new int[n];

        for (var i = 1; i < n; i++) {
            current = Math.Max(current + nums[i], nums[i]);
            max = Math.Max(current, max);
            sum[i] = sum[i-1] + nums[i];
            forward[i] = Math.Max(forward[i-1], sum[i]);
        }
        reverse[n-1] = nums[n-1];
        for (int i = n-2; i >= 0; i--) {
            reverse[i] = Math.Max(reverse[i+1], sum[n-1] - (i > 0 ? sum[i-1] : 0));
        }

        for (int i = 0; i < n; i++) {
            max = Math.Max(max, reverse[i] + (i > 0 ? forward[i-1] : 0));
        }

        return max;
    }
}