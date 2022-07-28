using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Valid_Anagram
{
    [TestClass]
    public class Valid_Anagram
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(IsAnagram("anagram", "nagaram"));
            Assert.IsTrue(IsAnagram("", ""));
            Assert.IsTrue(IsAnagram("a", "a"));
            Assert.IsTrue(IsAnagram("aaa", "aaa"));
            Assert.IsFalse(IsAnagram("a", "b"));
            Assert.IsFalse(IsAnagram("aaa", "bbb"));
            Assert.IsFalse(IsAnagram("rat", "car"));
            Assert.IsFalse(IsAnagram("rat", "nagaram"));
            Assert.IsFalse(IsAnagram("anagram", "car"));
        }

        public bool IsAnagram(string s, string t)
        {
            var dic = new Dictionary<char, int>();
            foreach (var chars in s)
                if (!dic.TryAdd(chars, 1)) dic[chars] += 1;

            foreach (var chart in t)
            {
                if (dic.ContainsKey(chart)) dic[chart] -= 1;
                else return false;
            }

            return dic.Values.All(x => x == 0);
        }
    }
}
