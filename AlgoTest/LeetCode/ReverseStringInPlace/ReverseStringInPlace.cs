using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ReverseStringInPlace
{
    class ReverseStringInPlace
    {
        public void ReverseString(char[] s)
        {
            if (s.Length == 1)
                return;
            var startIndex = 0;
            var endIndex = s.Length-1;

            while (startIndex < endIndex)
            {
                var replacement = s[startIndex];
                s[startIndex] = s[endIndex];
                s[endIndex] = replacement;

                startIndex += 1;
                endIndex -= 1;
            }

        }
    }
}
