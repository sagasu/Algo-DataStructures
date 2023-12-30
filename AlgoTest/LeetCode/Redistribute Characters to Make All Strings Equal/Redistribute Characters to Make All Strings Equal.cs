using System.Linq;

namespace AlgoTest.LeetCode.Redistribute_Characters_to_Make_All_Strings_Equal;

public class Redistribute_Characters_to_Make_All_Strings_Equal
{
    public bool MakeEqual(string[] words)
        =>
            words.SelectMany(s => s)
                .GroupBy(c => c)
                .All(g => g.Count() % words.Length == 0);
}