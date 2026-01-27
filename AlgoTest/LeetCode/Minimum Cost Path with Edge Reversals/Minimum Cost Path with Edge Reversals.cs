using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Cost_Path_with_Edge_Reversals;

public class Minimum_Cost_Path_with_Edge_Reversals
{
    public int MinCost(int n, int[][] edges)
    {
        List<(int to, int cost)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<(int, int)>();

        foreach (var e in edges)
        {
            int u = e[0], v = e[1], w = e[2];

            graph[u].Add((v, w));

            graph[v].Add((u, 2 * w));
        }

        // Dijkstra Algorithm
        long[] dist = new long[n];
        Array.Fill(dist, long.MaxValue);
        dist[0] = 0;

        var pq = new PriorityQueue<int, long>();
        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int node, out long cost);

            if (cost > dist[node]) continue;
            if (node == n - 1) break;

            foreach (var (next, w) in graph[node])
            {
                long newCost = cost + w;
                if (newCost < dist[next])
                {
                    dist[next] = newCost;
                    pq.Enqueue(next, newCost);
                }
            }
        }

        return dist[n - 1] == long.MaxValue ? -1 : (int)dist[n - 1];
    }
}