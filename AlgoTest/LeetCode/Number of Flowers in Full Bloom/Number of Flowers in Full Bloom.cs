using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Number_of_Flowers_in_Full_Bloom;

public class Number_of_Flowers_in_Full_Bloom
{
    public int[] FullBloomFlowers(int[][] flowers, int[] people) {
        var ops = new Dictionary<int, int>();
        ops[int.MaxValue] = 0;

        foreach (var flower in flowers) {
            ops[flower[0]] = ops.GetValueOrDefault(flower[0]) + 1;
            ops[flower[1] + 1] = ops.GetValueOrDefault(flower[1] + 1) - 1;
        }

        var sortedOps = ops.Select(kv => (Time: kv.Key, Op: kv.Value)).OrderBy(p => p.Time).ToArray();
        var peopleWithIndices = people.Select((p, i) => (Time: p, Index: i)).OrderBy(p => p.Time).ToArray();
        var ans = new int[people.Length];
        var cur = 0;
        var i = 0;

        foreach (var (time, index) in peopleWithIndices) {
            while (sortedOps[i].Time <= time)
                cur += sortedOps[i++].Op;
            ans[index] = cur;
        }

        return ans;
    }
}