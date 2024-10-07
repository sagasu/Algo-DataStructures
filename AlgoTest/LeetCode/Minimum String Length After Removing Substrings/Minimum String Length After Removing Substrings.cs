using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Minimum_String_Length_After_Removing_Substrings;

public class Minimum_String_Length_After_Removing_Substrings
{
    public int MinLength(string s) => s
        .Aggregate(
            new StringBuilder(),
            (acc, next) =>
                (acc.Length == 0 ? next : acc[^1], next) is ('A', 'B') or ('C', 'D') ?
                    acc.Remove(acc.Length - 1, 1) :
                    acc.Append(next),
            acc => acc.Length
        );
}