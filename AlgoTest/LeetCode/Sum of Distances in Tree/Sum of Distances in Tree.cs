using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Sum_of_Distances_in_Tree
{
    class Sum_of_Distances_in_Tree
    {
        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            


            var graph = new Dictionary<int, HashSet<int>>();
            int[] count = new int[N], result = new int[N];
            for (var i = 0; i < N; i++)
                graph[i] = new HashSet<int>();

            foreach (var e in edges)
            {
                int u = e[0], v = e[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }

            Dfs1(0, -1);
            Dfs2(0, -1);
            return result;

            void Dfs1(int node, int parent)
            {
                foreach (var neighbor in graph[node])
                {
                    if (neighbor == parent) continue;
                    Dfs1(neighbor, node);
                    count[node] += count[neighbor];
                    result[node] += result[neighbor] + count[neighbor];
                }
                count[node]++;
            }

            void Dfs2(int node, int parent)
            {
                foreach (var neighbor in graph[node])
                {
                    if (neighbor == parent) continue;
                    result[neighbor] = result[node] - count[neighbor] + count.Length - count[neighbor];
                    Dfs2(neighbor, node);
                }
            }
        }

        
    }
}
