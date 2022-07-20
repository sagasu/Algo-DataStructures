using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Number_of_Matching_Subsequences
{
    internal class Number_of_Matching_Subsequences
    {
        public int NumMatchingSubseq(string s, string[] words)
        {
            var dict = words.GroupBy(o => o).ToDictionary(o => o.Key, o => o.Count());
            var res = 0;
            foreach (var item in dict)
            {
                var pt = 0;
                foreach (var ts in s)
                {
                    if (item.Key[pt] == ts) pt++;
                    if (pt != item.Key.Length) continue;
                    res += item.Value;
                    break;
                }
            }
            return res;
        }
    }
}
