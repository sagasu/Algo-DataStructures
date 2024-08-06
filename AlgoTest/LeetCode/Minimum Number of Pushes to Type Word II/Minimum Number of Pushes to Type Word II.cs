using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Number_of_Pushes_to_Type_Word_II;

public class Minimum_Number_of_Pushes_to_Type_Word_II
{
    public int MinimumPushes(string word) => word.GroupBy(ch => ch).Select(g => g.Count()).OrderByDescending(_ => _).Select((cnt, i) => cnt * (i / 8 + 1)).Sum();
}