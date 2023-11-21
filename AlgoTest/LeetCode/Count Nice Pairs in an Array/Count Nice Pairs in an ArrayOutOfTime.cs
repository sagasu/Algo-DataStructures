using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_Nice_Pairs_in_an_Array;

[TestClass]
public class Count_Nice_Pairs_in_an_Array_OutOfTime
{
    [TestMethod]
    public void Test() => Assert.AreEqual(2, CountNicePairs(new[] { 42, 11, 1, 97 }));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(4, CountNicePairs(new[] { 13,10,35,24,76 }));
    
    public int CountNicePairs(int[] nums)
    {
        var rev = new int[nums.Length];
        for (var i = 0;i<nums.Length;i++)
            rev[i] = int.Parse(new string(nums[i].ToString().Reverse().ToArray()));
        
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
            for (var j = i+1; j < nums.Length; j++)
                if (nums[i] + rev[j] == nums[j] + rev[i]) count += 1;
        
        return count;
    }
}