using System.Linq;

namespace AlgoTest.LeetCode.Remove_All_Occurrences_of_a_Substring;

public class Remove_All_Occurrences_of_a_Substring
{
    public string RemoveOccurrences(string s, string part) => 
        Enumerable.Repeat(0, s.Length).Aggregate(s, (curr, _) => curr.Contains(part) ? curr.Remove(curr.IndexOf(part), part.Length) : curr);

}