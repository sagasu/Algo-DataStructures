using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.GenerateParenthesis
{
    [TestClass]
    public class GenerateParenthesisProblem
    {
        [TestMethod]
        public void Test()
        {
            var result = GenerateParenthesis(3);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            GenerateParenthesis(n, "", result, 0);
            return result;
        }

        public void GenerateParenthesis(int n, string current, IList<string> result, int close)
        {
            if (n == 0)
            {
                while (close != 0)
                {
                    current += ")";
                    close -= 1;
                }
                result.Add(current);

                return;
            }

            GenerateParenthesis(n - 1, current + "(", result, close+1);
            if(close > 0)
                GenerateParenthesis(n, current + ")", result, close-1);
        }
    }
}
