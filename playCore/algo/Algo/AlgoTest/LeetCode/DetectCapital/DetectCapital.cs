using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.DetectCapital
{
    [TestClass]
    public class DetectCapital
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(DetectCapitalUse("USA"));
            Assert.IsTrue(DetectCapitalUse("leetcode"));
            Assert.IsTrue(DetectCapitalUse("Google"));
            Assert.IsFalse(DetectCapitalUse("FlaG"));
            Assert.IsFalse(DetectCapitalUse("mL"));
            Assert.IsFalse(DetectCapitalUse("mRZ"));
        }

        public bool DetectCapitalUse(string word)
        {
            if (string.IsNullOrEmpty(word))
                return true;

            var isUpper = char.IsUpper(word[word.Length - 1]);

            var isFirst = true;
            for (var i = 0; i < word.Length-1; i++)
            {
                if (isFirst)
                {
                    isFirst = false;
                    if (isUpper && char.IsUpper(word[i]) == false)
                        return false;
                }else if (word[i] == ' ')
                {
                    isFirst = true;
                }else if (char.IsUpper(word[i]) != isUpper)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
