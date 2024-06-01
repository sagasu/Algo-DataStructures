using System;
using System.Linq;

namespace AlgoTest.LeetCode.Score_of_a_String;

public class Score_of_a_String
{
    public int ScoreOfString(string s) => Enumerable
        .Range(0, s.Length - 1)
        .Sum(i => Math.Abs(s[i] - s[i + 1]));   
}