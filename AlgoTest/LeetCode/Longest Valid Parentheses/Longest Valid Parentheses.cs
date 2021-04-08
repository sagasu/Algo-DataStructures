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
        public void Test3()
        {
            Assert.AreEqual(6, LongestValidParentheses("))(())()"));
            Assert.AreEqual(6, LongestValidParentheses("))(())())"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, LongestValidParentheses("()"));
        }
        
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(4, LongestValidParentheses("(()()"));
        }
        
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual(2, LongestValidParentheses("()(()"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(12, LongestValidParentheses("))((())()())()"));
        }

        public int LongestValidParentheses(string s)
        {
            var chars = s.ToCharArray();
            var stack = new Stack<int>();
            var max = 0;
            var start = -1;
            var previousStart = -1;

            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                    stack.Push(i);
                else
                {
                    if (!stack.TryPop(out var openIndex))
                    {
                        start = i;
                        previousStart = -1;
                        continue;
                    }

                    if (previousStart == -1) previousStart = openIndex;

                    if (i == chars.Length -1 && previousStart != -1 && stack.Count != 0) return Math.Max(max, i - previousStart + 1);

                    max = stack.Count == 0 ? Math.Max(max, i - start) : Math.Max(max, i - openIndex + 1);
                }
            }

            return max;
        }
    }
}
