using System.Linq;

namespace AlgoTest.LeetCode.Make_Array_Elements_Equal_to_Zero;

public class Make_Array_Elements_Equal_to_Zero
{
    public int CountValidSelections(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        int sum = nums.Sum();
        int leftSum = 0;
        int rightSum = sum;
        
        for (int i = 0; i < n; i++) {
            if (nums[i] == 0) {
                if (leftSum - rightSum >= 0 && leftSum - rightSum <= 1) {
                    ans++;
                }
                if (rightSum - leftSum >= 0 && rightSum - leftSum <= 1) {
                    ans++;
                }
            } else {
                leftSum += nums[i];
                rightSum -= nums[i];
            }
        }
        return ans;
    }
}