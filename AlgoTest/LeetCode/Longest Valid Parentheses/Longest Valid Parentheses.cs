using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_Valid_Parentheses
{
    [TestClass]
    public class Longest_Valid_Parentheses
    {
        //Work in progress

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(2, LongestValidParentheses("(()"));
            Assert.AreEqual(4, LongestValidParentheses(")()())"));
            Assert.AreEqual(0, LongestValidParentheses(")"));
            Assert.AreEqual(0, LongestValidParentheses(")))"));
            Assert.AreEqual(12, LongestValidParentheses("))((())()())()"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, LongestValidParentheses("()"));
        }

        public int LongestValidParentheses(string s)
        {
            var chars = s.ToCharArray();
            var stack = new Stack<char>();
            var max = 0;
            var start = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                    stack.Push(chars[i]);
                else
                {
                    if (!stack.TryPop(out var result))
                    {
                        start = i;
                        continue;
                    }

                    max = Math.Max(max, i - start);
                }
            }

            if (start == 0) max += 1;

            return max;
        }
    }
}
