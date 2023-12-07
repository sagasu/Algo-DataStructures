using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Largest_Odd_Number_in_String;

[TestClass]
public class Largest_Odd_Number_in_String
{
    [TestMethod]
    public void Test() => Assert.AreEqual("35427", LargestOddNumber("35427"));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual("5", LargestOddNumber("52"));
    
    [TestMethod]
    public void Test3() => Assert.AreEqual("", LargestOddNumber("4206"));
    
    public string LargestOddNumber(string num)
    {
        for (var i = num.Length-1; i >=0 ; i--)
            if(int.Parse(num[i].ToString()) % 2 == 1)
                return num.Substring(0, i+1);

        return string.Empty;
    }
}