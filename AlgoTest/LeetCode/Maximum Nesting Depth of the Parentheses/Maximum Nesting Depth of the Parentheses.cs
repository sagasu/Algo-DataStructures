using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Nesting_Depth_of_the_Parentheses;

public class Maximum_Nesting_Depth_of_the_Parentheses
{
    public int MaxDepth(string s) => s
        .Aggregate(
            (depth: 0, max: 0),
            (acc, next) => (
                acc.depth += next switch {
                    '(' => 1,
                    ')' => -1,
                    _ => 0
                },
                Math.Max(acc.depth, acc.max)
            ),
            acc => acc.max
        );
}