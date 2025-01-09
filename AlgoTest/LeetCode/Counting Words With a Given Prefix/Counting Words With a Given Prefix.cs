using System.Linq;

namespace AlgoTest.LeetCode.Counting_Words_With_a_Given_Prefix;

public class Counting_Words_With_a_Given_Prefix
{
    public class Solution
    {
        public int PrefixCount(string[] words, string pref) => words.Count(word => IsPrefix(pref, word));

        static bool IsPrefix(string w1, string w2)
        {
            if (w1.Length > w2.Length) return false;

            return !w1.Where((t, i) => t != w2[i]).Any();
        }
    }
}