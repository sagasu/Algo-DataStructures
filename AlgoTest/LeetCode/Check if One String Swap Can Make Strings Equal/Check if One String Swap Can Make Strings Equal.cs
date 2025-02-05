using System;
using System.Linq;

namespace AlgoTest.LeetCode.Check_if_One_String_Swap_Can_Make_Strings_Equal;

public class Check_if_One_String_Swap_Can_Make_Strings_Equal
{
    public bool AreAlmostEqual(string s1, string s2) {
        var x1 = String.Concat(s1.Select((c,i) => (c,i)).Where(t => s2[t.i] != t.c).Select(t => $"{t.c}{s2[t.i]}"));
        return (x1.Length == 0 || x1.Length == 4) && x1.SequenceEqual(x1.Reverse());
    }
}