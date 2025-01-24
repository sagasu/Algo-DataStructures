using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Eventual_Safe_States;

public class Find_Eventual_Safe_States
{
    public IList<int> EventualSafeNodes(int[][] graph) {
        var N = graph.Length;
        var inGraph = Enumerable.Range(0, N).ToDictionary(i => i, i => new List<int>());
        var outDegrees = graph.Select(arr => arr.Length).ToArray();
        for (var i = 0; i < N; i++) {
            foreach (var j in graph[i]) {
                inGraph[j].Add(i);
            }
        }
        var queue = new Queue<int>();
        for (var i = 0; i < N; i++) {
            if (outDegrees[i] == 0) {
                queue.Enqueue(i);
            }
        }
        while (queue.Any()) {
            var node = queue.Dequeue();
            foreach (var prev in inGraph[node]) {
                outDegrees[prev]--;
                if (outDegrees[prev] == 0) {
                    queue.Enqueue(prev);
                }
            }
        }
        return Enumerable.Range(0, N).Where(i => outDegrees[i] == 0).ToList();
    }
}