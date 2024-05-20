namespace AlgoTest.LeetCode.Sum_of_All_Subset_XOR_Totals;

public class Sum_of_All_Subset_XOR_Totals
{
    public int SubsetXORSum(int[] nums) {
        var xorSum = 0;
        Backtracking(nums, ref xorSum, 0, 0);
        return xorSum;
    }
    
    void Backtracking(int[] nums, ref int xorSum, int xor, int index) {
        for (int i=index; i<nums.Length; i++) {
            xor = xor^nums[i];
            xorSum += xor;
            Backtracking(nums, ref xorSum, xor, i+1);
            xor = xor^nums[i];
        }
    }
}