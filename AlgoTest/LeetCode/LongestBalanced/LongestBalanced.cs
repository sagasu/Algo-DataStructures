using System;

namespace AlgoTest.LeetCode.LongestBalanced;

public class LongestBalanced2
{
    public int LongestBalanced(int[] nums) {
        Span<int> counts = stackalloc int[2];
        Span<int> set = stackalloc int[100001];
        
        foreach (var num in nums) { 
            if (set[num]++ == 0) { ++counts[num & 1]; }
        }
        
        int n = nums.Length;
        if (counts[0] == counts[1]) { return n; }

        int l = n - 1;
        while (l > 1) {
            int key = nums[l];
            if (set[key]-- == 1) { --counts[key & 1]; }

            if (counts[0] == counts[1]) { return l; }

            for (int i = l; i < n; ++i) {
                key = nums[i];
                if (set[key]++ == 0) { ++counts[key & 1]; }

                key = nums[i - l];
                if (set[key]-- == 1) { --counts[key & 1]; }

                if (counts[0] == counts[1]) { return l; }
            }

            if (l == 2) { break; }
            
            key = nums[n - l--];
            if (set[key]-- == 1) { --counts[key & 1]; }
            
            if (counts[0] == counts[1]) { return l; }

            for (int i = n - 1; i >= l; --i) {
                key = nums[i - l];
                if (set[key]++ == 0) { ++counts[key & 1]; }

                key = nums[i];
                if (set[key]-- == 1) { --counts[key & 1]; }

                if (counts[0] == counts[1]) { return l; }
            }

            --l;
        }

        return 0;
    }
}