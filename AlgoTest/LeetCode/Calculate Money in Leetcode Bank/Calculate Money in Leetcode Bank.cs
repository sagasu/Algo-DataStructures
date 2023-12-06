using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Calculate_Money_in_Leetcode_Bank;
[TestClass]
public class Calculate_Money_in_Leetcode_Bank
{
    [TestMethod]
    public void Test() => Assert.AreEqual(37, TotalMoney(10));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual(10, TotalMoney(4));
    
    public int TotalMoney(int n)
    {
        var sum = 0;
        var premium = 0;
        var amount = 1;
        for (var i = 1; i <= n; i++)
        {
            sum += amount++ + premium;
            if (i % 7 == 0)
            {
                premium += 1;
                amount = 1;
            }
        }

        return sum;
    }
}