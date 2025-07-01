using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Original_Typed_String_I;

public class Find_the_Original_Typed_String_I
{
    public int PossibleStringCount(string word) => Enumerable.
        Range(0, word.Length - 1).
        Sum(m => word[m] == word[m + 1] ? 1 : 0) + 1;
}