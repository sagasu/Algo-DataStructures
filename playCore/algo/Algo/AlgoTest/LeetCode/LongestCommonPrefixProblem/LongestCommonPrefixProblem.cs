using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace AlgoTest.LeetCode.LongestCommonPrefixProblem
{
    [TestClass]
    public class LongestCommonPrefixProblem
    {
        [TestMethod]
        public void Test()
        {
            var t = new[]{"flower", "flow", "flight"};
            Assert.AreEqual("fl", LongestCommonPrefix(t));
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            if (strs.Length == 1)
                return strs[0];

            var prefix = strs[0];

            for (var i = 1; i < strs.Length; i++)
            {
                var newPrefix = "";
                for (var j = 0; j < prefix.Length; j++)
                {
                    if (strs[i].Length <= j || prefix[j] != strs[i][j])
                    {
                        prefix = newPrefix;
                        break;
                    }

                    newPrefix += strs[i][j].ToString();
                }
            }

            return prefix;
        }
    }
}
