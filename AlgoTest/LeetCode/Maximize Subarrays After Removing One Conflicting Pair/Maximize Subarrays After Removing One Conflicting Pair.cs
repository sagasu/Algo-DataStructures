using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximize_Subarrays_After_Removing_One_Conflicting_Pair;

public class Maximize_Subarrays_After_Removing_One_Conflicting_Pair
{
    public long MaxSubarrays(int n, int[][] conflictingPairs) {
        int m = conflictingPairs.Length;
        var conflicts = new (int a, int b, int id)[m];
        for (int i = 0; i < m; i++) {
            int x = conflictingPairs[i][0], y = conflictingPairs[i][1];
            if (x > y) (x, y) = (y, x);
            conflicts[i] = (x, y, i);
        }
        var conflictAt = new List<(int b, int id)>[n + 2];
        for (int i = 0; i <= n + 1; i++) conflictAt[i] = new List<(int, int)>();
        foreach (var t in conflicts)
            conflictAt[t.a].Add((t.b, t.id));

        var comp = Comparer<(int, int)>.Create((u, v) => u.Item1 != v.Item1 ? u.Item1 - v.Item1 : u.Item2 - v.Item2);
        var set = new SortedSet<(int, int)>(comp);
        var firstB = new int[n + 2];
        var firstId = new int[n + 2];
        var secondB = new int[n + 2];

        for (int L = n; L >= 1; L--) {
            foreach (var p in conflictAt[L])
                set.Add(p);
            if (set.Count == 0) {
                firstB[L] = n + 1;
                firstId[L] = -1;
                secondB[L] = n + 1;
            } else {
                var it = set.Min;
                firstB[L] = it.Item1;
                firstId[L] = it.Item2;
                if (set.Count > 1) {
                    int sb = int.MaxValue;
                    bool skipped = false;
                    foreach (var e in set) {
                        if (!skipped && e.Item1 == it.Item1 && e.Item2 == it.Item2) {
                            skipped = true; continue;
                        }
                        sb = e.Item1; break;
                    }
                    secondB[L] = sb;
                } else {
                    secondB[L] = n + 1;
                }
            }
        }

        long totalAll = 0;
        for (int L = 1; L <= n; L++) {
            int maxR = firstB[L] - 1;
            if (maxR >= L) totalAll += (maxR - L + 1);
        }

        var delta = new long[m];
        for (int L = 1; L <= n; L++) {
            int id = firstId[L];
            if (id >= 0) {
                delta[id] += (long)(secondB[L] - firstB[L]);
            }
        }

        if (m == 0) return (long)n * (n + 1) / 2;
        long ans = 0;
        for (int i = 0; i < m; i++)
            ans = Math.Max(ans, totalAll + delta[i]);
        return ans;
    }
}