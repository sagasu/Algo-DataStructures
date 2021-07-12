using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Isomorphic_Strings
{
    [TestClass]
    public class Isomorphic_Strings
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, IsIsomorphic("egg", "add"));
            Assert.AreEqual(false, IsIsomorphic("foo", "bar"));
            Assert.AreEqual(true, IsIsomorphic("paper", "title"));
        }

        public bool IsIsomorphic(string s, string t)
        {
            var n1 = GetStringAsNumber(s);
            var n2 = GetStringAsNumber(t);

            for (var i = 0;i<n1.Count;i++)
            {
                if (n1[i] != n2[i]) return false;
            }

            return true;
        }

        private static List<int> GetStringAsNumber(string s)
        {
            var count = 0;
            var dic = new Dictionary<char, int>();
            var list = new List<int>(s.Length);
            foreach (var c in s.ToCharArray())
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, count);
                    list.Add(count);
                    count += 1;
                }
                else
                {
                    list.Add(dic[c]);
                }
            }

            return list;
        }
    }
}
