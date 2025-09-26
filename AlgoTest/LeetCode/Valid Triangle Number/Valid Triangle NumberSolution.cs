using System;

namespace AlgoTest.LeetCode.Valid_Triangle_Number;

public class Valid_Triangle_NumberSolution
{
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length;
        int ans = 0;
        for (int k = n - 1; k >= 2; k--) {
            int l = 0, r = k - 1;
            while (l < r) {
                if (nums[l] + nums[r] > nums[k]) {
                    ans += (r - l);
                    r--;
                } else {
                    l++;
                }
            }
        }
        return ans;
    }
}