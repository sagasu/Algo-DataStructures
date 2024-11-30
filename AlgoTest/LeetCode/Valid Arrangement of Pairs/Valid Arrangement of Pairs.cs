using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Valid_Arrangement_of_Pairs;

public class Valid_Arrangement_of_Pairs
{
    public int[][] ValidArrangement(int[][] pairs) {
        var graph = new Dictionary<int, Stack<int>>();
        var inDegree = new Dictionary<int, int>();
        var outDegree = new Dictionary<int, int>();

        foreach (var pair in pairs) {
            var start = pair[0];
            var end = pair[1];

            if (!graph.ContainsKey(start)) {
                graph[start] = new Stack<int>();
            }
            graph[start].Push(end);

            outDegree[start] = outDegree.GetValueOrDefault(start, 0) + 1;
            inDegree[end] = inDegree.GetValueOrDefault(end, 0) + 1;
        }

        var startNode = pairs[0][0]; 
        foreach (var node in graph.Keys.Where(node => outDegree.GetValueOrDefault(node, 0) > inDegree.GetValueOrDefault(node, 0)))
        {
            startNode = node;
            break;
        }

        var result = new List<int[]>();
        var stack = new Stack<int>();
        stack.Push(startNode);

        while (stack.Count > 0) {
            int node = stack.Peek();
            if (graph.ContainsKey(node) && graph[node].Count > 0) {
                stack.Push(graph[node].Pop());
            } else {
                stack.Pop();
                if (stack.Count > 0)
                    result.Add(new int[] { stack.Peek(), node });
            }
        }

        result.Reverse();
        return result.ToArray();
    }
}