namespace AlgoTest.LeetCode.Count_Subarrays_of_Length_Three_With_a_Condition;

public class Count_Subarrays_of_Length_Three_With_a_Condition
{
    public int CountSubarrays(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2) {
                ++ans;
            }
        }
        return ans;
    }
}