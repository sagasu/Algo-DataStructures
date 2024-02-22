using System.Linq;

namespace AlgoTest.LeetCode.Find_the_Town_Judge;

public class Find_the_Town_Judge
{
    public int FindJudge(int n, int[][] trust) {
        return trust.GroupBy(t => t[1])
            .Where(g => g.Count() == n - 1)
            .Select(g => g.Key)
            .Except(trust.Select(t => t[0]))
            .SingleOrDefault(n == 1 ? 1 : -1);
    }
}