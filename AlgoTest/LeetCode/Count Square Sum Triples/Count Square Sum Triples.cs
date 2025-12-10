using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Square_Sum_Triples;

public class Count_Square_Sum_Triples
{
    public int CountTriples(int n) {
        var set = new HashSet<int>();
        for (int i = 1; i <= n; i++) set.Add(i * i);
        var rs = 0;
        foreach(var item0 in set)
        {
            foreach(var item1 in set)
            {
                if (set.Contains(item0 + item1)) rs++;
            }
        }
        return rs;
    }
}