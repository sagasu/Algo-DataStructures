namespace AlgoTest.LeetCode.Kth_Smallest_Product_of_Two_Sorted_Arrays;

public class Kth_Smallest_Product_of_Two_Sorted_Arrays
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k) {
        long left = -10000000000L, right = 10000000000L;

        while (left < right) {
            long mid = left + (right - left) / 2;
            if (CountLessEqual(nums1, nums2, mid) >= k) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }

        return left;
    }

    private long CountLessEqual(int[] nums1, int[] nums2, long x) {
        long count = 0;

        foreach (int num1 in nums1) {
            if (num1 > 0) {
                int l = 0, r = nums2.Length;
                while (l < r) {
                    int m = (l + r) / 2;
                    if ((long)num1 * nums2[m] <= x) {
                        l = m + 1;
                    } else {
                        r = m;
                    }
                }
                count += l;
            }
            else if (num1 < 0) {
                int l = 0, r = nums2.Length;
                while (l < r) {
                    int m = (l + r) / 2;
                    if ((long)num1 * nums2[m] <= x) {
                        r = m;
                    } else {
                        l = m + 1;
                    }
                }
                count += nums2.Length - l;
            }
            else {
                if (x >= 0) count += nums2.Length;
            }
        }

        return count;
    }
}