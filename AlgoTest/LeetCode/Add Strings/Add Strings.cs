using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Add_Strings
{
    [TestClass]
    public class Add_Strings
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
            var sb = new StringBuilder();
            var min = Math.Min(num1.Length, num2.Length);
            var l1 = num1.Length-1;
            var l2 = num2.Length-1;
            var rest = 0;
            var i = 0;
            for (; i < min; i++)
            {
                var sum = int.Parse(num1[l1-i].ToString()) + int.Parse(num2[l2-i].ToString()) + rest;
                if (sum > 9)
                {
                    rest = 1;
                    sum -= 10;
                }
                else rest = 0;

                sb.Append(sum);
            }

            
            while (l1 >= i)
            {
                var sum = int.Parse(num1[l1 - i].ToString()) + rest;
                if (sum > 9)
                {
                    sb.Append(sum - 10);
                    rest = 1;
                }
                else {sb.Append(sum); rest = 0; }

                i+=1;
            }
            while (l2 >= i)
            {
                var sum = int.Parse(num2[l2 - i].ToString()) + rest;
                if (sum > 9)
                {
                    sb.Append(sum - 10);
                    rest = 1;
                }
                else{ sb.Append(sum); rest = 0; }
                i += 1;
            }

            if (rest == 1) sb.Append(1);
            return string.Join("",sb.ToString().Reverse());
        }
    }
}
