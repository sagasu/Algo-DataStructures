namespace AlgoTest.LeetCode.Rearrange_Array_Elements_by_Sign;

public class Rearrange_Array_Elements_by_Sign
{
    public int[] RearrangeArray(int[] nums) {
        var n = nums.Length;
        var ans = new int[n];
        
        int posIndex = 0, negIndex = 1;

        for (var i = 0; i < n; i++) {
            if (nums[i] > 0) {
                ans[posIndex] = nums[i];
                posIndex += 2;
            } else {
                ans[negIndex] = nums[i];
                negIndex += 2;
            }
        }

        return ans;
    }
}