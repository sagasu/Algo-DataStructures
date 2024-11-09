namespace AlgoTest.LeetCode.Maximum_XOR_for_Each_Query;

public class Maximum_XOR_for_Each_Query
{
    public int[] getMaximumXor(int[] nums, int maximumBit) {
        int n = nums.Length;
        int xorVal = 0;
        int togglePoint = (1 << maximumBit) - 1; 
        foreach (int x in nums) {
            xorVal ^= x;
        }

        int[] ans = new int[n];
        for (int i = 0; i < n; i++) {
            ans[i] = xorVal ^ togglePoint;
            xorVal ^= nums[n - 1 - i];
        }

        return ans;
    }
}