using System.Collections.Generic;

namespace AlgoTest.LeetCode.Rabbits_in_Forest;

public class Rabbits_in_Forest
{
    public int NumRabbits(int[] answers) {
        var count = new Dictionary<int, int>();
        foreach (int a in answers) {
            if (!count.ContainsKey(a)) count[a] = 0;
            count[a]++;
        }

        int res = 0;
        foreach (var kv in count)
            res += ((kv.Value + kv.Key) / (kv.Key + 1)) * (kv.Key + 1);

        return res;
    }
}