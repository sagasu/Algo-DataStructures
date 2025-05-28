using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_I;

public class Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_I
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        List<int>[] g1 = new List<int>[n], g2 = new List<int>[m];
        foreach(int i in Enumerable.Range(0, n)) {
            g1[i] = new List<int>();
        }
        foreach(int i in Enumerable.Range(0, m)) {
            g2[i] = new List<int>();
        }
        foreach(int[] edge in edges1) {
            g1[edge[0]].Add(edge[1]);
            g1[edge[1]].Add(edge[0]);
        }
        foreach(int[] edge in edges2) {
            g2[edge[0]].Add(edge[1]);
            g2[edge[1]].Add(edge[0]);
        }
        int max2 = 0;
        for (int i = 0; i < m; i++) {
            max2 = Math.Max(max2, Dfs(g2, i, -1, k - 1));
        }
        int[] answ = new int[n];
        for (int i = 0; i < n; i++) {
            answ[i] = max2;
            answ[i] += Dfs(g1, i, -1, k);
        }
        return answ;
    }
    int Dfs(List<int>[] g, int node, int parent, int k) {
        if (k < 0) {
            return 0;
        }
        if (k == 0)
            return 1;
        int res = 1;
        foreach(int next in g[node]) {
            if (next == parent) {
                continue;
            }
            res += Dfs(g, next, node, k - 1);
        }
        return res;
    }
}