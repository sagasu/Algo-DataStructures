using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Count_Vowels_Permutation
{
    internal class Count_Vowels_Permutation
    {
        public int CountVowelPermutation(int n)
        {
            var Mod = 1000000007;

            long[] next = new long[5] { 1, 1, 1, 1, 1 }, curr = new long[5];

            for (var i = n - 1; i > 0; i--)
            {
                curr[0] = next[1];
                curr[1] = (next[0] + next[2]) % Mod;
                curr[2] = (next[0] + next[1] + next[3] + next[4]) % Mod;
                curr[3] = (next[2] + next[4]) % Mod;
                curr[4] = next[0];

                (next, curr) = (curr, next);
            }

            return (int)(next.Sum() % Mod);
        }
    }
}
