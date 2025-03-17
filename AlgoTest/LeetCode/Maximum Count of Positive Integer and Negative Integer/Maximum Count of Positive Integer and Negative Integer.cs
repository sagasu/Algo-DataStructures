using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Maximum_Count_of_Positive_Integer_and_Negative_Integer;

[TestClass]
public class Maximum_Count_of_Positive_Integer_and_Negative_Integer
{
    [TestMethod]
    public void Test() => Assert.IsTrue(MaximumCount(new int[] { -2, -1, -1, 1, 2, 3 }) == 3);
    
    [TestMethod]
    public void Test1() => Assert.IsTrue(MaximumCount(new int[] { -3,-2,-1,0,0,1,2 }) == 3);
    
    [TestMethod]
    public void Test2() => Assert.IsTrue(MaximumCount(new int[] { 5,20,66,1314 }) == 4);
    
    public int MaximumCount(int[] nums)
    {
        var countNegative = 0;
        var countPositive = 0;
        foreach (var num in nums)
        {
            if (num > 0) countPositive++;
            if (num < 0) countNegative++;
        }

        return Math.Max(countNegative, countPositive);
    }
}