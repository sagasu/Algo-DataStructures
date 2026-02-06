namespace AlgoTest.LeetCode.Transformed_Array;

public class Transformed_Array
{
    public int[] ConstructTransformedArray(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = nums[((i + nums[i]) % n + n) % n];
        }
        return res;
    }
}