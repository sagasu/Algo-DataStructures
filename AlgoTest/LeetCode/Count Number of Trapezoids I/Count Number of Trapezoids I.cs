using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Number_of_Trapezoids_I;

public class Count_Number_of_Trapezoids_I
{
    private const int MOD = 1000000007;
    public int CountTrapezoids(int[][] points) {
        var dict = new Dictionary<int, int>();
        foreach (var p in points) {
            int y = p[1];
            if (!dict.ContainsKey(y)) dict[y] = 0;
            dict[y]++;
        }

        List<long> pairs = new List<long>();
        foreach (var kv in dict) {
            int c = kv.Value;
            if (c >= 2) {
                long ways = (long)c * (c - 1) / 2;
                pairs.Add(ways);
            }
        }
        long res = 0;
        long pref = 0;
        foreach (var val in pairs) {
            res = (res + val * pref) % MOD;
            pref = (pref + val) % MOD;
        }

        return (int)res;
    }
}