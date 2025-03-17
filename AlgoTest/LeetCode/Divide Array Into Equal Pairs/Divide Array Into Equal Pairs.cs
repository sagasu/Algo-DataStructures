using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Divide_Array_Into_Equal_Pairs;

[TestClass]
public class Divide_Array_Into_Equal_Pairs
{
    [TestMethod]
    public void Test1() => Assert.IsTrue(DivideArray(new[] { 3, 2, 3, 2, 2, 2 }));
    
    [TestMethod]
    public void Test2() =>  Assert.IsFalse(DivideArray(new[] {1,2,3,4}));
    
    public bool DivideArray(int[] nums)
    {
        var dic = new Dictionary<int, int>();
        foreach (var num in nums)
            if (!dic.TryAdd(num, 1)) dic[num]++;

        return dic.Keys.All(key => dic[key] % 2 == 0);
    }
}