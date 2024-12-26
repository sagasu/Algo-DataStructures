using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Target_Sum;

public class Target_Sum
{
    Dictionary<(int, int, int), int> memo = new Dictionary<(int, int, int), int>();
    
    public int FindTargetSumWays(int[] nums, int S) => HowManyWays(nums, 0, nums.Length - 1, S);
    
    int HowManyWays(int[] nums, int left, int right, int sum)
    {
        if(memo.ContainsKey((left, right, sum)))
            return memo[(left, right, sum)];
        
        var res = 0;
        if(left == right)
        {
            if(nums[left] == sum || nums[left] == -1*sum)
                res = sum == 0 ? 2 : 1;
        }
        else
            res = HowManyWays(nums, left+1, right, sum-nums[left]) + HowManyWays(nums, left+1, right, sum+nums[left]);
        
        memo[(left, right, sum)] = res;
        return res;
    }
}