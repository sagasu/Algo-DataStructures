using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.IntegerToRoman2
{
    [TestClass]
    public class IntegerToRoman
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("XII", IntToRoman(12));
            Assert.AreEqual("IX", IntToRoman(9));
            Assert.AreEqual("IV", IntToRoman(4));
            Assert.AreEqual("CXXII", IntToRoman(122));
            Assert.AreEqual("CDL", IntToRoman(450));
        }

        private IDictionary<int, string> mapping = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

        public string IntToRoman(int num)
        {
            var roman = new StringBuilder();

            foreach(var key in mapping.Keys)
            {
                var count = num / key;
                num = num % key;

                for (var j = 0; j < count; j++)
                {
                    roman.Append(mapping[key]);
                }
            }

            return roman.ToString();
        }
    }
}
