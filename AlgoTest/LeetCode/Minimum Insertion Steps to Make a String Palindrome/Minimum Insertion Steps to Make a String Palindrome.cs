using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Insertion_Steps_to_Make_a_String_Palindrome
{
    internal class Minimum_Insertion_Steps_to_Make_a_String_Palindrome
    {
        public int MinInsertions(string s)
        {
            var n = s.Length;
            var charArr = s.ToCharArray();
            Array.Reverse(charArr);
            var reverse = new string(charArr);

            var dp1 = new int[n + 1];
            var dp2 = new int[n + 1];

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    if (s[i - 1] == reverse[j - 1]) dp2[j] = 1 + dp1[j - 1];
                    else dp2[j] = Math.Max(dp1[j], dp2[j - 1]);
                }

                Array.Copy(dp2, 0, dp1, 0, n + 1);
            }

            return n - dp1[n];
        }
    }
}
