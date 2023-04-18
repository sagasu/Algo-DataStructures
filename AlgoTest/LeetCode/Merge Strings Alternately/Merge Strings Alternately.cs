using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Merge_Strings_Alternately
{
    [TestClass]
    public class Merge_Strings_Alternately
    {
        [TestMethod]
        public void Test() => Assert.AreEqual("apbqcr", MergeAlternately("abc", "pqr"));
        
        [TestMethod]
        public void Test2() => Assert.AreEqual("apbqcrs2", MergeAlternately("abc", "pqrs2"));
        
        [TestMethod]
        public void Test3() => Assert.AreEqual("apbqcd", MergeAlternately("abcd", "pq"));

        public string MergeAlternately(string word1, string word2)
        {
            var sb = new StringBuilder();
            var j = 0;
            for (var i = 0; i < word1.Length; i++)
            {
                sb.Append(word1[i]);
                if (j < word2.Length) sb.Append(word2[j++]);
            }

            return sb.Append(string.Join("", word2.Skip(j))).ToString();
        }
    }
}
