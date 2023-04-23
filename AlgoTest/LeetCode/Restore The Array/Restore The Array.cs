using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Restore_The_Array
{
    public class Restore_The_Array
    {
        public int NumberOfArrays(string s, int k)
        {
            var tab = new int[s.Length + 1];
            tab[0] = 1;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '0') continue;
                long num = 0;
                for (var len = 1; i + len <= s.Length; len++)
                {
                    num = (10 * num) + s[i + len - 1] - '0';
                    if (num > k) break;
                    tab[i + len] = (tab[i + len] + tab[i]) % 1_000_000_007;
                }
            }

            return tab[s.Length];
        }
    }
}
