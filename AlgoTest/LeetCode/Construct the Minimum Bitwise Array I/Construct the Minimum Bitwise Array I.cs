using System.Collections.Generic;

namespace AlgoTest.LeetCode.Construct_the_Minimum_Bitwise_Array_I;

public class Construct_the_Minimum_Bitwise_Array_I
{
    public int[] MinBitwiseArray(IList<int> nums) {
        int[] ans = new int[nums.Count];
        for(int i = 0; i < nums.Count; i++) {
            int n = nums[i];
            if(n != 2) ans[i] = n - ((n + 1) & (-n - 1)) / 2;
            else ans[i] = -1;
        }  
        return ans;
    }
}