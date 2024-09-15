using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Longest_Substring_Containing_Vowels_in_Even_Counts;

public class Find_the_Longest_Substring_Containing_Vowels_in_Even_Counts
{
    public int FindTheLongestSubstring(string s) => s
        .Select((c, i) => (i, j: "aeiou".IndexOf(c)))
        .Aggregate(
            (map: new Dictionary<int, int> {{0,-1}}, mask: 0, max: 0),
            (acc, next) => (
                acc.map,
                acc.mask ^= next.j == -1 ? 0 : 1 << next.j,
                Math.Max(acc.max, next.i - (acc.map.TryGetValue(acc.mask, out int k) ? k : acc.map[acc.mask] = next.i))
            ),
            acc => acc.max
        );
}