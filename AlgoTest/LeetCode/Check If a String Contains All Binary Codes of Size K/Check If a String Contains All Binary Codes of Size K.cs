using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Check_If_a_String_Contains_All_Binary_Codes_of_Size_K
{
    internal class Check_If_a_String_Contains_All_Binary_Codes_of_Size_K
    {
        public bool HasAllCodes(string s, int k)
        {
            var expectedCount = (long)Math.Pow(2, k);
            long num = 0;
            var maxMask = expectedCount - 1;
            var codes = new HashSet<long>();

            for (var i = 0; i < s.Length; i++)
            {
                num <<= 1;
                num |= (s[i] == '0' ? 0 : 1);
                num &= maxMask;

                if (i + 1 >= k) codes.Add(num);
            }

            return codes.Count == expectedCount;
        }
    }
}
