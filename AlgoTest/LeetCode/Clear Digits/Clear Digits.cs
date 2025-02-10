using System;
using System.Linq;

namespace AlgoTest.LeetCode.Clear_Digits;

public class Clear_Digits
{
    public string ClearDigits(string s) => s.Aggregate("", (prev, c) => Char.IsDigit(c) ? prev[..^1] : (prev + c));
}