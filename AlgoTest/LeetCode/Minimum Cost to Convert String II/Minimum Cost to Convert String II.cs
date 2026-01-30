using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Cost_to_Convert_String_II;

public class Minimum_Cost_to_Convert_String_II
{
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost) {
        int n = source.Length;
        long INF = (long)1e18;

        var id = new Dictionary<string, int>();
        int idx = 0;

        void add(string s) {
            if (!id.ContainsKey(s)) id[s] = idx++;
        }

        for (int i = 0; i < original.Length; i++) {
            add(original[i]);
            add(changed[i]);
        }

        for (int i = 0; i < n; i++) {
            add(source[i].ToString());
            add(target[i].ToString());
        }

        long[,] dist = new long[idx, idx];
        for (int i = 0; i < idx; i++)
            for (int j = 0; j < idx; j++)
                dist[i, j] = i == j ? 0 : INF;

        for (int i = 0; i < original.Length; i++) {
            int u = id[original[i]];
            int v = id[changed[i]];
            dist[u, v] = Math.Min(dist[u, v], cost[i]);
        }

        for (int k = 0; k < idx; k++)
            for (int i = 0; i < idx; i++)
                for (int j = 0; j < idx; j++)
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                        dist[i, j] = dist[i, k] + dist[k, j];

        var byLen = new Dictionary<int, List<(string o, string c)>>();

        for (int i = 0; i < original.Length; i++) {
            int len = original[i].Length;
            if (!byLen.ContainsKey(len))
                byLen[len] = new List<(string, string)>();
            byLen[len].Add((original[i], changed[i]));
        }

        long[] dp = new long[n + 1];
        for (int i = 0; i <= n; i++) dp[i] = INF;
        dp[0] = 0;

        for (int i = 0; i < n; i++) {
            if (dp[i] == INF) continue;

            if (source[i] == target[i])
                dp[i + 1] = Math.Min(dp[i + 1], dp[i]);

            foreach (var kv in byLen) {
                int len = kv.Key;
                if (i + len > n) continue;

                string s = source.Substring(i, len);
                string t = target.Substring(i, len);

                if (!id.ContainsKey(s) || !id.ContainsKey(t)) continue;

                long c = dist[id[s], id[t]];
                if (c < INF)
                    dp[i + len] = Math.Min(dp[i + len], dp[i] + c);
            }
        }

        return dp[n] == INF ? -1 : dp[n];
    }
}