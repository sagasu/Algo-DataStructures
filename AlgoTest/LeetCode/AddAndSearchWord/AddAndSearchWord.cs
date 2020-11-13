using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.AddAndSearchWord
{
    [TestClass]
    public class WordDictionary
    {
        [TestMethod]
        public void TesT()
        {
            AddWord("bad");
            AddWord("dad");
            AddWord("mad");

            Assert.IsFalse(Search("pad"));
            Assert.IsTrue(Search("bad"));
            Assert.IsTrue(Search(".ad"));
            Assert.IsTrue(Search("b.."));
        }


        private List<string> dic = new List<string>();

        /** Initialize your data structure here. */
        public WordDictionary()
        {

        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            dic.Add(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            foreach (var dicWord in dic)
            {
                var min = Math.Min(word.Length, dicWord.Length);
                if(min != word.Length && word.Length != dicWord.Length)
                    continue;
                
                for (var i = 0; i < dicWord.Length; i++)
                {
                    if ((dicWord[i] == word[0] || word[0] == '.')&& CheckPattern(dicWord, word, i))
                        return true;
                }
            }

            return false;
        }

        private bool CheckPattern(string dicWord, string word, int dicIndex)
        {
            for (var i = 1; i < dicWord.Length - dicIndex; i++)
            {
                if (i == word.Length)
                    return true;

                if (dicWord[i + dicIndex] != word[i] && word[i] != '.')
                    return false;
            }

            return true;
        }
    }
}
