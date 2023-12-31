using System.Linq;

namespace AlgoTest.LeetCode.Largest_Substring_Between_Two_Equal_Characters;

public class Largest_Substring_Between_Two_Equal_Characters
{
    public int MaxLengthBetweenEqualCharacters(string s) => s
        .Distinct()
        .Max(c => s.LastIndexOf(c) - s.IndexOf(c) - 1);
}