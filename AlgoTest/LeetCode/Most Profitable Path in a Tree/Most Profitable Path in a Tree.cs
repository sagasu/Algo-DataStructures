using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Most_Profitable_Path_in_a_Tree;

public class Most_Profitable_Path_in_a_Tree
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount) {
        int n = edges.Length+1;
        List<int>[] g = new List<int>[n];
        for(int i=0;i<n;i++)
            g[i] = new();
        foreach(var e in edges)
        {
            g[e[0]].Add(e[1]);  // u-> v
            g[e[1]].Add(e[0]);  // v-> u
        }

        // Trace the path b/w Alice and Bob
        bool[] visited = new bool[n];
        visited[0] = true;
        Trace(0, new Stack<int>());

        // calculate max profit for Alice
        int maxProfitForAlice = int.MinValue;
        visited = new bool[n];
        visited[0] = true;
        DFS(0, 0);
        return maxProfitForAlice;

        // local helper func
        void Trace(int idx, Stack<int> st)
        {
            st.Push(idx);
            // check if reached bob
            if (idx == bob)
            {
                // remove the amount part that bob earned
                var ls = st.ToArray();
                int lt = 0, rt = ls.Length - 1;
                while (lt < rt)
                {
                    amount[ls[lt]] = 0;
                    lt++;
                    rt--;
                }
                if (lt == rt)   // common node gets halved
                    amount[ls[lt]] = (amount[ls[lt]] != 0 ? amount[ls[lt]] / 2 : 0);
            }
            else // keep moving frwd till we find bob
                foreach (var adj in g[idx])
                    if(!visited[adj])
                    {
                        visited[adj] = true;
                        Trace(adj, st);
                    }
            st.Pop();
            
        }
        void DFS(int idx, int aliceProfit)
        {
            // add cur node value to total profit so far
            aliceProfit += amount[idx];
            // reset the cur node profit
            amount[idx] = 0;
            
            foreach (var adj in g[idx])
                if (!visited[adj])
                {
                    visited[adj] = true;
                    DFS(adj, aliceProfit);
                }

            if (g[idx].Count == 1 && idx != 0) // leaf node
                maxProfitForAlice = Math.Max(maxProfitForAlice, aliceProfit);
        }
    }
}