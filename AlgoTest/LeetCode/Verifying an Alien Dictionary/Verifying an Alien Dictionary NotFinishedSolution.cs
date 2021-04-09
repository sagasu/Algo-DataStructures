using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Verifying_an_Alien_Dictionary1
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

            decimal Hash(IEnumerable<char> chars)
            {
                var hash = "";
                foreach (var character in chars)
                {
                    hash += dic[character];
                }

                return decimal.Parse(hash);
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
                //min = Math.Min(h1, h2);
                var compare = h1.CompareTo(h2);

                return compare == 0? s1.Length.CompareTo(s2.Length): compare;
            });

            for (int i = 0; i < sortedWord.Count; i++)
            {
                if (sortedWord[i] != words[i]) return false;
            }

            return true;
        }

    }
}
