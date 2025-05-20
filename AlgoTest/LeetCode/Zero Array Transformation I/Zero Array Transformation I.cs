namespace AlgoTest.LeetCode.Zero_Array_Transformation_I;

public class Zero_Array_Transformation_I
{
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] freq = new int[n + 1]; 
        foreach (var query in queries) {
            int l = query[0];
            int r = query[1];
            freq[l]++;
            if (r + 1 < n) {
                freq[r + 1]--;
            }
        }
        for (int i = 1; i < n; i++) {
            freq[i] += freq[i - 1];
        }
        for (int i = 0; i < n; i++) {
            if (nums[i] > freq[i]) {
                return false;
            }
        }

        return true;
    }
}