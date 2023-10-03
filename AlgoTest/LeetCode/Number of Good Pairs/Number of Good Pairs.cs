using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Good_Pairs;

public class Number_of_Good_Pairs
{
    public int NumIdenticalPairs(int[] A) => A
        .GroupBy(x => x)
        .Select(g => g.Count())
        .Sum(c => c * (c - 1) / 2);
}