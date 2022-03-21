using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Partition_Labels
{
    internal class Partition_Labels
    {
        public IList<int> PartitionLabels(string s)
        {
            if (string.IsNullOrEmpty(s)) return new List<int>();
            var map = new Dictionary<char, int>();
            var ret = new List<int>();
            for (var i = 0; i < s.Length; i++)
                map[s[i]] = i;
            var end = 0; int counter = 0;
            for (var i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, map[s[i]]);
                counter++;
                if (i != end) continue;
                ret.Add(counter);
                counter = 0;

            }
            return ret;
        }
    }
}
