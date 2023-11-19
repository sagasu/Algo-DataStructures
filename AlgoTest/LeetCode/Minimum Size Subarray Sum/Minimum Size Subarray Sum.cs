using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Size_Subarray_Sum;

[TestClass]
public class Minimum_Size_Subarray_Sum
{
    [TestMethod]
    public void TesT() => Assert.AreEqual(2, MinSubArrayLen(7, new[] { 2, 3, 1, 2, 4, 3 }));
    
    public int MinSubArrayLen(int target, int[] nums) {
        var n = nums.Length;
        var ans = int.MaxValue;
        var left = 0;
        var sum = 0;
        for (var i = 0; i < n; i++) {
            sum += nums[i];
            while (sum >= target) {
                ans = Math.Min(ans, i + 1 - left);
                sum -= nums[left++];
            }
        }
        
        return (ans != int.MaxValue) ? ans : 0;
    }
}