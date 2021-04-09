using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Verifying_an_Alien_Dictionary
{
    [TestClass]
    public class Verifying_an_Alien_Dictionary
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] {"hello", "leetcode"};
            var p = "hlabcdefgijkmnopqrstuvwxyz";
            Assert.AreEqual(true, IsAlienSorted(t,p));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[] { "word", "world", "row" };
            var p = "worldabcefghijkmnpqstuvxyz";
            Assert.AreEqual(false, IsAlienSorted(t,p));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new string[] { "apple", "app" };
            var p = "abcdefghijklmnopqrstuvwxyz";
            Assert.AreEqual(false, IsAlienSorted(t,p));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new string[] { "mtkwpj", "wlaees" };
            var p = "evhadxsqukcogztlnfjpiymbwr";
            Assert.AreEqual(true, IsAlienSorted(t,p));
        }
        
        [TestMethod]
        public void Test5()
        {
            var t = new string[] { "kuvp", "q" };
            var p = "ngxlkthsjuoqcpavbfdermiywz";
            Assert.AreEqual(true, IsAlienSorted(t,p));
        }

        public bool IsAlienSorted(string[] words, string order)
        {
            var dic = new Dictionary<char, int>();

            int[] Hash(IEnumerable<char> chars)
            {

                var characters = chars.ToList();
                var ret = new int[characters.Count];
                for(var i=0;i<characters.Count;i++)
                {
                    ret[i] = dic[characters[i]];
                }

                return ret;
            }

            for (int i = 0; i < order.Length; i++)
            {
                dic[order[i]] = i + 1;
            }

            var sortedWord = words.ToList();
            sortedWord.Sort((s1,s2) =>
            {
                var min = Math.Min(s1.Length, s2.Length);
                var h1 = Hash(s1.Take(min));
                var h2 = Hash(s2.Take(min));
                var compare = 0;
                for (var i = 0; i < h1.Length; i++)
                {
                    var comp = h1[i].CompareTo(h2[i]);
                    if (comp!=0) return comp;
                }

                return s1.Length.CompareTo(s2.Length);
            });

            for (int i = 0; i < sortedWord.Count; i++)
            {
                if (sortedWord[i] != words[i]) return false;
            }

            return true;
        }

    }
}
