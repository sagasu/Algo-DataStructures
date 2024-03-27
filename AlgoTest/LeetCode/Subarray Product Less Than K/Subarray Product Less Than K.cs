namespace AlgoTest.LeetCode.Subarray_Product_Less_Than_K;

public class Subarray_Product_Less_Than_K
{
    public int NumSubarrayProductLessThanK (int[] nums, int k) {
        int left = 0, right = 0, result = 0, product = 1;

        while (right < nums.Length) {
            product *= nums[right];
            while (left <= right && product >= k)
                product /= nums[left++];
            result += right - left + 1;
            right++;
        }

        return result;
    }
}