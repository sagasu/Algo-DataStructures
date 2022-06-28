using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Deletions_to_Make_Character_Frequencies_Unique
{
    internal class Minimum_Deletions_to_Make_Character_Frequencies_Unique
    {
        public int MinDeletions(string s)
        {
            var res = 0;
            var dict = s.GroupBy(o => o).ToDictionary(o => o.Key, o => o.Count());
            var hs = new HashSet<int>();
            foreach (var item in dict)
            {
                var cur = item.Value;
                while (!hs.Add(cur) && cur > 0)
                {
                    res++;
                    cur--;
                }
            }
            return res;
        }
    }
}
