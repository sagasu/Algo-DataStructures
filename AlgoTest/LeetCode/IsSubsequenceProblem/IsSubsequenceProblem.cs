using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.IsSubsequenceProblem
{
    [TestClass]
    public class IsSubsequenceProblem
    {
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var index = 0;
            for (var i = 0; i < t.Length; i++)
            {

                if (s.Length == index)
                    return true;

                if (t[i] == s[index])
                {
                    index += 1;
                }
            }

            return s.Length == index;
        }
    }
}
