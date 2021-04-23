using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Count_Binary_Substrings
{
    [TestClass]
    public class Count_Binary_Substrings
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(6, CountBinarySubstrings("00110011"));
        }

        public int CountBinarySubstrings(string s)
        {
            var groups = new List<int>();

            var current = 1;
            foreach (var index in Enumerable.Range(1,s.Length-1))
            {
                if (s[index] != s[index - 1])
                {
                    groups.Add(current);
                    current = 1;
                }
                else
                    current += 1;
            }
            groups.Add(current);

            var total = 0;
            groups.Zip(groups.Skip(1), (first, second) => total += Math.Min(first, second)).ToList();
            return total;
        }
    }
}
