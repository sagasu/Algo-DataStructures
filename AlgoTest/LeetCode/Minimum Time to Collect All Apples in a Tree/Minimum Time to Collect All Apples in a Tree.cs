using System.Collections.Generic;

public class MinTimeSolution
{
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
        var adj = new List<int>[n];
        var degree = new int[n];
        for (var i = 0; i < n; i++) adj[i] = new List<int>();
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
            degree[edge[0]]++;
            degree[edge[1]]++;
        }
        
        var queue = new Queue<int>();
        for (var i = 1; i < n; i++) {
            if (degree[i] == 1) queue.Enqueue(i);
        }
        
        var count = 0;
        while(queue.Count > 0) {
            var v = queue.Dequeue();
            if (hasApple[v]) count += 2;
            foreach (var u in adj[v]) {
                degree[u]--;
                if (hasApple[v]) hasApple[u] = true;
                if (u != 0 && degree[u] == 1) {
                    queue.Enqueue(u);
                }
            }
        }
        
        return count;
    }
}   