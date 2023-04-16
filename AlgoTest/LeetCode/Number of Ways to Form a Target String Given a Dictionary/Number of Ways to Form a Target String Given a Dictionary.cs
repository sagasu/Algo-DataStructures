using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary
{
    public class Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary
    {
        public int NumWays(string[] words, string target)
        {
            var mod = 1000000007;
            var dp = new long[target.Length + 1, words[0].Length + 1];
            dp[0, 0] = 1;
            var ways = new int[26, words[0].Length];

            for (var i = 0; i < words[0].Length; i++)
            {
                foreach (string word in words)
                    ways[word[i] - 'a', i]++;
            }

            
            for (var i = 0; i <= target.Length; i++)
            {
                for (var j = 0; j < words[0].Length; j++)
                {
                    if (i < target.Length)
                    {
                        dp[i + 1, j + 1] += ways[target[i] - 'a', j] * dp[i, j];
                        dp[i + 1, j + 1] %= mod;
                    }

                    dp[i, j + 1] += dp[i, j];
                    dp[i, j + 1] %= mod;
                }
            }
            return (int)dp[target.Length, words[0].Length];
        }
    }
}
