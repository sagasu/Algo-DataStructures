using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Removing_Stars_From_a_String
{
    [TestClass]
    public class Removing_Stars_From_a_String
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("lecoe", RemoveStars("leet**cod*e"));
        }
        public string RemoveStars(string s)
        {
            var stack = new Stack<char>();
            
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '*') stack.TryPop(out _);
                else stack.Push(s[i]);
            }

            return string.Join("", stack.Reverse());
        }
    }
}
