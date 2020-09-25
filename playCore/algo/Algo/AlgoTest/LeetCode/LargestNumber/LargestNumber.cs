using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LargestNumber
{
    [TestClass]
    public class LargestNumberSolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {3, 30, 34, 5, 9};

            Assert.AreEqual("9534330", LargestNumber(t));
        }

        public string LargestNumber(int[] nums)
        {
            var ret = string.Join("", nums.OrderBy(x => x.ToString(), new NumberCompare()));

            return ret[0] == '0' ? "0" : ret;
        }

        class NumberCompare : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var str1 = x + y;
                var str2 = y + x;
                return str2.CompareTo(str1);
            }
        }
    }
}
