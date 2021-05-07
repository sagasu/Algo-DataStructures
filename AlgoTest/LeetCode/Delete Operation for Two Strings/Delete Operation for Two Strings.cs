using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Delete_Operation_for_Two_Strings
{
    public class Delete_Operation_for_Two_Strings
    {
        // "Edit Distance" problem, it is just that we have delete operation
        public int MinDistance(string word1, string word2)
        {
            var cache = new int?[word1.Length+1, word2.Length+1];

            int MinD(int index1, int index2)
            {
                if (index1 == word1.Length && index2 == word2.Length) return 0;
                if (index1 == word1.Length) return MinD(index1, index2 + 1) + 1;
                if (index2 == word2.Length) return MinD(index1 + 1, index2) + 1;
                if (cache[index1, index2].HasValue) return cache[index1, index2].Value;

                var mn = int.MaxValue;
                if (word1[index1] == word2[index2])
                    mn = Math.Min(mn, MinD(index1 + 1, index2 + 1));
                mn = Math.Min(mn, MinD(index1 + 1, index2) + 1);
                mn = Math.Min(mn, MinD(index1, index2 + 1) + 1);
                cache[index1, index2] = mn;
                return mn;
            }

            return MinD(0, 0);
        }
    }
}
