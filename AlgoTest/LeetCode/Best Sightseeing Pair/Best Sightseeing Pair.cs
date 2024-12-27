using System;
using System.Linq;

namespace AlgoTest.LeetCode.Best_Sightseeing_Pair;

public class Best_Sightseeing_Pair
{
    public int MaxScoreSightseeingPair(int[] values) => values.Aggregate((Result: 0, Current: 0),
        (t, a) => (Math.Max(t.Result, t.Current + a), Math.Max(t.Current, a) - 1), t => t.Result);
}