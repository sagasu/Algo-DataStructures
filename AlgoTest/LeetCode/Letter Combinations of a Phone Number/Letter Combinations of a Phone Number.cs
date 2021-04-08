using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Letter_Combinations_of_a_Phone_Number
{
    [TestClass]
    public class Letter_Combinations_of_a_Phone_Number
    {
        [TestMethod]
        public void Test()
        {
            var t = new List<string>(){ "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            var ret = LetterCombinations("23").ToList();
            CollectionAssert.AreEqual(t, ret);
        }

        IDictionary<char,List<string>> dic = new Dictionary<char, List<string>>()
        {
            {'2', new List<string>() {"a", "b", "c"}},
            {'3', new List<string>() {"d", "e", "f"}},
            {'4', new List<string>() {"g", "h", "i"}},
            {'5', new List<string>() {"j", "k", "l"}},
            {'6', new List<string>() {"m", "n", "o"}},
            {'7', new List<string>() {"p", "q", "r", "s"}},
            {'8', new List<string>() {"t", "u", "v"}},
            {'9', new List<string>() {"w", "x", "y", "z"}},
        };

        public IList<string> LetterCombinations(string digits)
        {
            if(digits.Length == 0) return new List<string>();

            var number = digits[0];

            if (digits.Length == 1)
            {
                return dic[number];
            }
            var ret = new List<string>();
            var lc = LetterCombinations(digits.Substring(1));
            for (var i = 0; i < dic[number].Count; i++)
            {
                for (var j = 0; j < lc.Count; j++)
                {
                     ret.Add(dic[number][i]+lc[j]);
                }
            }

            return ret;

        }
    }
}
