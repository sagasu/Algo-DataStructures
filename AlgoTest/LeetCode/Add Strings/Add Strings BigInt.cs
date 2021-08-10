using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Add_Strings
{
    // This solution is much slower than the array based one 144ms, 27.3MB
    [TestClass]
    public class Add_Strings_BigInt
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("134", AddStrings("11", "123"));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("533", AddStrings("456", "77"));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("0", AddStrings("0", "0"));
        }
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("10", AddStrings("9", "1"));
        }
        
        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("108", AddStrings("9", "99"));
        }
        
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual("7030", AddStrings("6994", "36"));
        }

        public string AddStrings(string num1, string num2)
        {
            var n1 = BigInteger.Parse(num1);
            var n2 = BigInteger.Parse(num2);
            var sum = n1 + n2;
            return sum.ToString();

        }
    }
}
