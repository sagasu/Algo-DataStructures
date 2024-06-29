using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph;

public class All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        var adj = new List<int>[n];
        var ans = new List<IList<int>>();

        for(var i=0; i<n; i++)
        {
            adj[i] = new List<int>();
            ans.Add(new List<int>());
        }
        
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adj[u].Add(v);
        }
        for(var i=0; i<n; i++)
        {
            var visited = new bool[n];
            Dfs(i, visited, adj);
            for(int j=0; j<n; j++)
            {
                if(i!=j && visited[j])
                {
                    ans[j].Add(i);
                }
            }
        }
        return ans;
    }

    void Dfs(int i, bool[] visited, List<int>[] adj)
    {
        visited[i] = true;
        foreach (var item in adj[i].Where(item => !visited[item]))
            Dfs(item, visited, adj);
    }
}