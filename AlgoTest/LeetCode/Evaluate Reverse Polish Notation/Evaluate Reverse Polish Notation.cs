using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Evaluate_Reverse_Polish_Notation
{
    [TestClass]
    public class Evaluate_Reverse_Polish_Notation
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[] {"2", "1", "+", "3", "*"};
            Assert.AreEqual(9,EvalRPN(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[] { "4", "13", "5", "/", "+" };
            Assert.AreEqual(6,EvalRPN(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"};
            Assert.AreEqual(22,EvalRPN(t));
        }

        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<string>();

            var index = 0;
            while (stack.Count != 1 || index != tokens.Length)
            {
                if (tokens[index] == "+")
                {
                    var a = int.Parse(stack.Pop());
                    var b = int.Parse(stack.Pop());
                    stack.Push((a + b).ToString());
                }
                else if (tokens[index] == "-")
                {
                    var a = int.Parse(stack.Pop());
                    var b = int.Parse(stack.Pop());
                    stack.Push((b - a).ToString());
                }
                else if (tokens[index] == "*")
                {
                    var a = int.Parse(stack.Pop());
                    var b = int.Parse(stack.Pop());
                    stack.Push((a * b).ToString());
                }
                else if (tokens[index] == "/")
                {
                    var a = int.Parse(stack.Pop());
                    var b = int.Parse(stack.Pop());
                    stack.Push((b/a).ToString());
                }else
                    stack.Push(tokens[index]);

                index += 1;
            }

            return int.Parse(stack.Pop());
        }
    }
}
