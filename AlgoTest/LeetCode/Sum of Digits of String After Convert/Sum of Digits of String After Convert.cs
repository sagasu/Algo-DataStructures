using System.Linq;

namespace AlgoTest.LeetCode.Sum_of_Digits_of_String_After_Convert;

public class Sum_of_Digits_of_String_After_Convert
{
    public int GetLucky(string s, int k) => s
        .Aggregate(
            0,
            (acc, next) => char.IsLetter(next) ?
                acc + (next - 'a' + 1) / 10 + (next - 'a' + 1) % 10 :
                acc + next - '0',
            acc => k == 1 ? acc : GetLucky($"{acc}", k - 1)
        );
}