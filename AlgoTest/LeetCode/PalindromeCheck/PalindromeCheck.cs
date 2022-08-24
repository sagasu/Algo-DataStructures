using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PalindromeCheck
{
    [TestClass]
    public class PalindromeCheck
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(IsPalindrome(121));
            Assert.IsTrue(IsPalindrome(1001));
        }

        public bool IsPalindrome(int x)
        {
            var xs = x.ToString();

            if (x < 0) return false;

            if(xs.Length == 1) return true;

            for (var i = 0; i < (xs.Length / 2); i++)
            {

                var pairElement = xs[xs.Length - i - 1];
                if (xs[i] != pairElement) return false;
            }

            return true;
        }
    }
}
