using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.AnagramCheck
{
    [TestClass]
    public class AnagramCheck
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(IsAnagram("anagram", "nagaram"));
        }

        public bool IsAnagram(string s, string t)
        {
            var hs = new Dictionary<char, int>();
            var sa = s.ToCharArray();
            var ta = t.ToCharArray();
            foreach (var c in sa)
                hs[c] = hs.ContainsKey(c) ? hs[c] + 1 : 1;
            

            foreach (var i in ta)
            {
                if (!hs.ContainsKey(i))
                    return false;

                hs[i] -= 1;
            }

            foreach (var hsKey in hs.Keys)
            {
                if (hs[hsKey] != 0)
                    return false;
            }

            return true;
        }
    }
}
