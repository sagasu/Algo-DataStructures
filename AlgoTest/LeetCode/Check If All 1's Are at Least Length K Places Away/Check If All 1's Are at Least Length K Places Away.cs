namespace AlgoTest.LeetCode.Check_If_All_1_s_Are_at_Least_Length_K_Places_Away;

public class Check_If_All_1_s_Are_at_Least_Length_K_Places_Away
{
    public bool KLengthApart(int[] nums, int k) {
        int last = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 1) {
                if (last >= 0 && i - last - 1 < k) return false;
                last = i;
            }
        }
        return true;
    }
}