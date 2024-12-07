using System.Linq;

namespace AlgoTest.LeetCode.Adding_Spaces_to_a_String;

public class Adding_Spaces_to_a_String
{
    public string AddSpaces(string s, int[] spaces) =>
        string.Join(" ", spaces.Prepend(0).Zip(spaces.Append(s.Length), (a, b) => s.Substring(a, b - a)));
}