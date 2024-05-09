using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximize_Happiness_of_Selected_Children;

public class Maximize_Happiness_of_Selected_Children
{
    public long MaximumHappinessSum(int[] H, int k) => H
        .OrderDescending()
        .Select((h, i) => Math.Max(0L, h - i))
        .Take(k)
        .Sum(); 
}