using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LetterCombinationsPhoneNumber
{
    [TestClass]
    public class LetterCombinationsPhoneNumber
    {
        [TestMethod]
        public void Test()
        {
            var res = LetterCombinations("23");
            Assert.AreEqual(9, res.Count);
        }

        List<string> mapping  = new List<string>
        {
            "",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        public IList<string> LetterCombinations(string digits)
        {
            var options = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return options;

            var ar = digits.ToCharArray();
            Letters(ar, 0, "", options);
            return options;
        }

        public void Letters(char[] digits, int index, string current, List<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(current);
                return;
            }

            var lettersForNumber = mapping[digits[index]-'0'];
            foreach (var c in lettersForNumber)
            {
                Letters(digits, index + 1, current + c, result);
            }
        }
    }
}
