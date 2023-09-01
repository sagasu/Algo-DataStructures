using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Counting_Bits;

[TestClass]
public class Counting_Bits
{
    [TestMethod]
    public void Test() => Assert.IsTrue(CountBits(2) is [0, 1, 1]);
    
    [TestMethod]
    public void Test1() => Assert.IsTrue(CountBits(5) is [0,1,1,2,1,2]);
    
    public int[] CountBits(int n)
    {
        var ones = new int[n + 1];
        for (var i = 0; i <= n;i++)
            ones[i] = Convert.ToString(i, 2).Count(x => x == '1');

        return ones;
    }
}