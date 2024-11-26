using System.Linq;

namespace AlgoTest.LeetCode.Find_Champion_II;

public class Find_Champion_II
{
    public int FindChampion(int n, int[][] edges) {
        var result = Enumerable
            .Range(0, n)
            .Except(edges.Select(edge => edge[1]))
            .ToList();

        return result.Count == 1 ? result[0] : -1;            
    }
}