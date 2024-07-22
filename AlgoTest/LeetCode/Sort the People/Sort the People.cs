using System.Linq;

namespace AlgoTest.LeetCode.Sort_the_People;

public class Sort_the_People
{
    public string[] SortPeople(string[] N, int[] H) => N
        .Zip(H, (n, h) => (n, h))
        .OrderByDescending(t => t.h)
        .Select(t => t.n)
        .ToArray();
}