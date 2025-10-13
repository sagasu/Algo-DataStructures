using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Resultant_Array_After_Removing_Anagrams;

public class Find_Resultant_Array_After_Removing_Anagrams
{
    public IList<string> RemoveAnagrams(string[] words) => words.
        Aggregate(("", new List<string>()), (value, current) =>
        {
            return string.Concat(current.OrderBy(m => m)) == value.Item1
                ? value
                : new(string.Concat(current.OrderBy(m => m)), [.. value.Item2, current]);
        }, current => current.Item2);
}