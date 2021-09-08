using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Shifting_Letters
{
    class Shifting_Letters
    {
        public string ShiftingLetters(string s, int[] shifts)
        {
            var chars = s.ToCharArray();
            var requiredShifts = new int[shifts.Length];

            var sum = 0;
            for (var i = shifts.Length - 1; i >= 0; i--)
            {
                sum = (sum + shifts[i]) % 26;
                requiredShifts[i] = sum;
            }

            for (var j = 0; j < chars.Length; j++)
            {
                var next = (chars[j] - 'a' + requiredShifts[j] + 26) % 26;
                chars[j] = (char)(next + 'a');
            }

            return new string(chars);
		}
    }
}
