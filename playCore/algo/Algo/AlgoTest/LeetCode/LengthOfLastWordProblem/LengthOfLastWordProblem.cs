using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.LengthOfLastWordProblem
{
    class LengthOfLastWordProblem
    {
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;

            var elements = s.Split(' ');
            var lastElement = elements[elements.Length - 1];
            return lastElement.Length;
        }
    }
}
