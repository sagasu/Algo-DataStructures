using System.Linq;

namespace AlgoTest.LeetCode.Path_Crossing;

public class Path_Crossing
{
    public bool IsPathCrossing(string P, int x = 0, int y = 0) => P
        .Select(c => c switch {
            'N' => (x, ++y),
            'S' => (x, --y),
            'E' => (++x, y),
            _  => (--x, y),
        })
        .Append((0, 0))
        .Distinct()
        .Count() <= P.Length;
}