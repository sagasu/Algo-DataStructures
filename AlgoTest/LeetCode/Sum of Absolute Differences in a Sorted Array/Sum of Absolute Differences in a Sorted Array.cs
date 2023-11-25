using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Sum_of_Absolute_Differences_in_a_Sorted_Array;

[TestClass]
public class Sum_of_Absolute_Differences_in_a_Sorted_Array
{
    [TestMethod]
    public void Test() => Assert.IsTrue(GetSumAbsoluteDifferences(new []{2,3,5}) is [4,3,5]);
    
    public int[] GetSumAbsoluteDifferences(int[] nums) {
        var n = nums.Length;
        var prefix = new int[n];
        prefix[0] = nums[0];
        for (var i = 1; i < n; i++) 
            prefix[i] = prefix[i - 1] + nums[i];
        
        
        var ans = new int[n];
        for (var i = 0; i < n; i++) {
            var leftSum = prefix[i] - nums[i];
            var rightSum = prefix[n - 1] - prefix[i];
            
            var leftCount = i;
            var rightCount = n - 1 - i;
            
            var leftTotal = leftCount * nums[i] - leftSum;
            var rightTotal = rightSum - rightCount * nums[i];
            
            ans[i] = leftTotal + rightTotal;
        }
        
        return ans;
    }
}