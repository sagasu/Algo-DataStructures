using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_II;

public class Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_II
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2) {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] ans = CountDistant(n, ref edges1, true);
        int add = CountDistant(m, ref edges2, false).Max();
        for(int i=0; i<n; i++)
            ans[i] += add;
        return ans;
    }

    public int[] CountDistant(int n, ref int[][] edge, bool even){
        int[] color = new int[n];
        // fill all distances
        List<int>[] tree = BuildTree(n, ref edge);
        color[0] = 1;
        // queue
        Queue<int> qu = new();
        qu.Enqueue(0);
        int iter = 1;
        // BFS
        while (qu.Count > 0) {
            // level by level traversal
            int c = qu.Count();
            for(int i=0; i<c; i++){
                int curr = qu.Dequeue();
                foreach (int next in tree[curr])
                    if (color[next]==0) {
                        color[next] = (iter%2==0) ? 1 : 2;
                        qu.Enqueue(next);
                    }
            }
            iter++;
        } 
        // fill the answer
        int c1 = 0, c2 =0;
        for(int i=0; i<n; i++)
            if(color[i]==1) c1++;
            else c2++;
        int[] ans = new int[n];
        for(int i=0; i<n; i++)
            if(even) ans[i] += (color[i] == 1) ? c1 : c2;
            else ans[i] += (color[i] == 2) ? c1 : c2;
        return ans;
    }

    private List<int>[] BuildTree(int size, ref int[][] edges) {
        List<int>[] tree = new List<int>[size];
        for (int i = 0; i < size; i++)
            tree[i] = new List<int>();
        foreach (var edge in edges) {
            tree[edge[0]].Add(edge[1]);
            tree[edge[1]].Add(edge[0]);
        }
        return tree;
    }
}