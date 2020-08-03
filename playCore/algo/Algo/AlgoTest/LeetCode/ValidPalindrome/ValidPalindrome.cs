using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ValidPalindrome
{
    [TestClass]
    public class ValidPalindrome
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true, IsPalindrome("A man, a plan, a canal: Panama"));
        }

        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var i = 0;
            var j = s.Length-1;

            var alphanumeric = new Regex("^[a-zA-Z0-9]*$");

            while (i<j)
            {
                while (i < j)
                {
                    if (char.IsLetterOrDigit(s[i]))
                    {
                        break;
                    }

                    i += 1;
                }

                while (i<j)
                {
                    if (char.IsLetterOrDigit(s[j]))
                    {
                        break;
                    }

                    j -= 1;
                }

                var equal = char.ToUpperInvariant(s[i]) == char.ToUpperInvariant(s[j]);
                if (!equal)
                {
                    return false;
                }

                i += 1;
                j -= 1;
            }

            return true;

        }
    }
}
