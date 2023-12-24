using System;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Changes_To_Make_Alternating_Binary_String;

public class Minimum_Changes_To_Make_Alternating_Binary_String
{
    public int MinOperations(string s) => Math.Min(
        s.Select((c, i) => (c + i) % 2).Sum(),
        s.Select((c, i) => (c + i + 1) % 2).Sum());
}