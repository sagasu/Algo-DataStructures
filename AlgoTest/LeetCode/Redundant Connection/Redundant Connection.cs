using System;

namespace AlgoTest.LeetCode.Redundant_Connection;

public class Redundant_Connection
{
    public int[] FindRedundantConnection(int[][] edges) {
        var n = edges.Length;
        var uf = new int[n+1];

        Array.Fill(uf, -1);
        foreach (int[] edge in edges){
            var idx1 = Find(uf, edge[0]);
            var idx2 = Find(uf, edge[1]);
            if(idx1 == idx2)
                return edge;
            uf[idx1] = idx2;
        }
        return edges[n-1];
    }

    int Find(int[] uf, int node) => uf[node]==-1 ? node : Find(uf, uf[node]);
}