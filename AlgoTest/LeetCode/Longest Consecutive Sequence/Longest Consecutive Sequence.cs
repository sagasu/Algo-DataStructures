using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Longest_Consecutive_Sequence
{
    internal class Longest_Consecutive_Sequence
    {
        public int LongestConsecutive(int[] nums)
        {
            var hs = new HashSet<int>(nums);
            var ret = 0;
            foreach (var n in hs)
            {
                if (hs.Contains(n - 1)) continue;
                var curr = n;
                var cnt = 1;
                while (hs.Contains(curr + cnt)) cnt++;

                ret = Math.Max(ret, cnt);
            }
            return ret;
        }
    }
}
