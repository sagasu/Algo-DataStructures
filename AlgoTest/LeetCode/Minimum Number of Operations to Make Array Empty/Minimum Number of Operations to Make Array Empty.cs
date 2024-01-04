using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Number_of_Operations_to_Make_Array_Empty;

[TestClass]
public class Minimum_Number_of_Operations_to_Make_Array_Empty
{
    [TestMethod]
    public void Test() => Assert.AreEqual(4, MinOperations(new[] { 2, 3, 3, 2, 2, 4, 2, 3, 4 }));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(-1, MinOperations(new[] { 2,1,2,2,3,3 }));
    
    [TestMethod]
    public void Test3() => Assert.AreEqual(7, MinOperations(new[] { 14,12,14,14,12,14,14,12,12,12,12,14,14,12,14,14,14,12,12 }));

    public int MinOperations(int[] nums)
    {
        Array.Sort(nums);
        var dic = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
            if (!dic.TryAdd(nums[i], 1))
                dic[nums[i]] += 1;


        var count = 0;
        foreach (var val in dic.Values)
        {
            if (val == 1)
                return -1;
            
            count += (int)Math.Ceiling((double)val / 3);
        }

        return count;
    }
}