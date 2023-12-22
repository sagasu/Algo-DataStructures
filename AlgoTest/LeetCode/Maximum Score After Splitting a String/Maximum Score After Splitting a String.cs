using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Score_After_Splitting_a_String;

public class Maximum_Score_After_Splitting_a_String
{
    public int MaxScore(string s) => s
        .Aggregate(
            (max: -1, zeros: 0, ones: s.Sum(c => c - '0')),
            (acc, next) => (
                acc.max == -1 ? 0 : Math.Max(acc.max, acc.zeros + acc.ones),
                acc.zeros + ('1' - next),
                acc.ones - (next - '0')
            ),
            acc => acc.max
        );
}