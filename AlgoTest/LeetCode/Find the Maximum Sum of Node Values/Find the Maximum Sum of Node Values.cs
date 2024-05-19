using System;

namespace AlgoTest.LeetCode.Find_the_Maximum_Sum_of_Node_Values;

public class Find_the_Maximum_Sum_of_Node_Values
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges) {
        var n = nums.Length;
        var dp = new long[n + 1, 2];
        
        dp[n, 1] = 0;
        dp[n, 0] = long.MinValue;
        
        for (var index = n - 1; index >= 0; index--) {
            for (var isEven = 0; isEven <= 1; isEven++) {
                var dontPerformOperation = dp[index + 1, isEven] + nums[index];
                var performOperation = dp[index + 1, isEven ^ 1] + (nums[index] ^ k);
                
                dp[index, isEven] = Math.Max(dontPerformOperation, performOperation);
            }
        }
        return dp[0, 1];
    }
}