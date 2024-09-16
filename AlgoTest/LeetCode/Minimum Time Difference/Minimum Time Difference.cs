using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Minimum_Time_Difference;

public class Minimum_Time_Difference
{
    public int FindMinDifference(IList<string> timePoints)
    {
        var times = timePoints.Select(TimeOnly.Parse).Order().ToArray();
        var differences = times.Prepend(times[^1]).Zip(times, (a, b) => b - a);
        return (int)differences.Min().TotalMinutes;
    }
}