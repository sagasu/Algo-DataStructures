using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Prefix_and_Suffix_Search
{
    [TestClass]
    // this solves different problem, because it assumes that prefix and suffix are symmetrical 
    public class Prefix_and_Suffix_Search_DifferentPRoblem
    {
        [TestMethod]
        public void Test()
        {
            var wf = new WordFilter(new []{"apple"});
            Assert.AreEqual(0, wf.F("a","e"));
        }
        
        [TestMethod]
        public void Test2()
        {
            var wf = new WordFilter(new []{"apple", "apple" , "apple" });
            Assert.AreEqual(2, wf.F("a","e"));
        }
        
        [TestMethod]
        public void Test3()
        {
            var wf = new WordFilter(new []{"apple", "apple" , "apple" });
            Assert.AreEqual(-1, wf.F("a",""));
        }
        
        [TestMethod]
        public void Test4()
        {
            var wf = new WordFilter(new []{"abc", "apple" , "apple" });
            Assert.AreEqual(0, wf.F("a","c"));
        }
        
        [TestMethod]
        public void Test5()
        {
            var wf = new WordFilter(new []{"ab", "apple" , "apple" });
            Assert.AreEqual(0, wf.F("a","b"));
        }

        [TestMethod]
        public void Test6()
        {
            var wf = new WordFilter(new[] { "cabaabaaaa", "ccbcababac", "bacaabccba", "bcbbcbacaa", "abcaccbcaa", "accabaccaa", "cabcbbbcca", "ababccabcb", "caccbbcbab", "bccbacbcba" });
            Assert.AreEqual(9, wf.F("bccbacbcba", "a"));
            Assert.AreEqual(4, wf.F("ab", "abcaccbcaa"));
            Assert.AreEqual(5, wf.F("a", "aa"));
            Assert.AreEqual(0, wf.F("cabaaba", "abaaaa"));
            Assert.AreEqual(8, wf.F("cacc", "accbbcbab"));
            Assert.AreEqual(1, wf.F("ccbcab", "bac"));
            Assert.AreEqual(2, wf.F("bac", "cba"));
        }

        //["WordFilter","f","f","f","f","f","f","f","f","f","f"]
        //[[["cabaabaaaa","ccbcababac","bacaabccba","bcbbcbacaa","abcaccbcaa","accabaccaa","cabcbbbcca","ababccabcb","caccbbcbab","bccbacbcba"]],["ac","accabaccaa"],["bcbb","aa"],["ccbca","cbcababac"]]

        public class WordFilter
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            string Hash(string start, string end) => $"{start}_{end}";
            public WordFilter(string[] words)
            {
                for (var i = 0; i <words.Length;i++)
                {
                    var word = words[i];
                    var start = 0;
                    var end = word.Length-1;
                    var prefix = new StringBuilder();
                    var suffix = new StringBuilder();
                    while (start <= end)
                    {
                        prefix.Append(word[start]);
                        suffix.Append(word[end]);
                        var hash = Hash(prefix.ToString(), suffix.ToString());

                        if (dic.ContainsKey(hash))
                            dic[hash] = i;
                        else
                            dic.Add(hash, i);
                        start += 1;
                        end -= 1;
                    }
                }
                
            }

            public int F(string prefix, string suffix)
            {
                var hash = Hash(prefix, suffix);
                return dic.ContainsKey(hash) ? dic[hash] : -1;
            }
        }
    }
}
