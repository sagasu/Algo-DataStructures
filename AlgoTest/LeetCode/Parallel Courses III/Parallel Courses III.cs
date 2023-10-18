using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Parallel_Courses_III;

public class Parallel_Courses_III
{
    public int MinimumTime(int n, int[][] relations, int[] time) {
        var graph = new Dictionary<int, List<int>>();
        for (var i = 0; i < n; i++) 
            graph[i] = new List<int>();
        
        
        var indegree = new int[n];
        foreach (var edge in relations) {
            var x = edge[0] - 1;
            var y = edge[1] - 1;
            graph[x].Add(y);
            indegree[y]++;
        }
        
        var queue = new Queue<int>();
        var maxTime = new int[n];
        
        for (var node = 0; node < n; node++) {
            if (indegree[node] == 0) {
                queue.Enqueue(node);
                maxTime[node] = time[node];
            }
        }
        
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            foreach (var neighbor in graph[node]) {
                maxTime[neighbor] = Math.Max(maxTime[neighbor], maxTime[node] + time[neighbor]);
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) 
                    queue.Enqueue(neighbor);
            }
        }
        
        var ans = 0;
        for (var node = 0; node < n; node++) 
            ans = Math.Max(ans, maxTime[node]);
        
        return ans;        
    }
}