namespace AlgoTest.LeetCode.Longest_Subarray_With_Maximum_Bitwise_AND;

public class Longest_Subarray_With_Maximum_Bitwise_AND
{
    public int LongestSubarray(int[] nums) {
        int n = nums.Length;
        
        int maxA = nums[0];
        for (int i = 1; i < n; i++) {
            if (nums[i] > maxA) 
                maxA = nums[i];
        }
        
        int res = 0, c = 0;
        for (int i = 0; i < n; i++) {
            if ((nums[i] & maxA) == maxA) {
                c++;
                if (c > res) 
                    res = c;
            } else {
                c = 0;
            }
        }
        
        return res;
    }
}