using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Largest_3_Same_Digit_Number_in_String;

[TestClass]
public class Largest_3_Same_Digit_Number_in_String
{
    [TestMethod]
    public void Test() => Assert.AreEqual("777", LargestGoodInteger("6777133339"));
    
    [TestMethod]
    public void Test2() => Assert.AreEqual("000", LargestGoodInteger("2300019"));
    
    public string LargestGoodInteger(string num)
    {

        if (string.IsNullOrEmpty(num)) return string.Empty;
        var previous = num[0];
        var count = 1;
        var maxNum = -1;
        for (var i = 1; i< num.Length;i++)
        {
            if(num[i] != previous)
                count = 1;
            
            if (num[i] == previous) count++;
            
            if (count == 3) maxNum = Math.Max(maxNum, int.Parse(num[i].ToString()));
            
            previous = num[i];
        }

        return maxNum == -1 ? string.Empty: $"{maxNum}{maxNum}{maxNum}";
    }
}