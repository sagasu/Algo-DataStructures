using System.Linq;

namespace AlgoTest.LeetCode.Count_Prefix_and_Suffix_Pairs_I;

public class Count_Prefix_and_Suffix_Pairs_I
{
    public int CountPrefixSuffixPairs(string[] words) =>
        Enumerable
            .Range(0, words.Length)
            .SelectMany(i => Enumerable.Range(i + 1, words.Length - i - 1).Select(j => (i, j)))
            .Aggregate(0, (r, p) => words[p.j].StartsWith(words[p.i]) && words[p.j].EndsWith(words[p.i]) ? r + 1 : r);
}