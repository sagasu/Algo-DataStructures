using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Shortest_Path_Visiting_All_Nodes;

public class Shortest_Path_Visiting_All_Nodes
{
    public int ShortestPathLength(int[][] graph) {
        var myQueue1 = new Queue<Tuple<int, int, int>>();
        var maxLen = 1 << graph.Length + 1;
        var filter = new int[maxLen, graph.Length]; 
        
        for (var i = 0; i < graph.Length; ++i)
        {
            filter[1 << i, i] = 1;
            myQueue1.Enqueue(new Tuple<int, int, int>(1 << i, i, 0));
        }
        
        while (myQueue1.Count != 0)
        {
            var myQueue = new Queue<Tuple<int, int, int>>();
            while (myQueue1.Count != 0)
            {
                var node = myQueue1.Dequeue();
                if (node.Item1 == (1 << graph.Length) - 1)
                    return node.Item3;

                for (var i = 0; i < graph[node.Item2].Length; ++i)
                {
                    var tuple = new Tuple<int, int, int>(node.Item1 | 1 << graph[node.Item2][i],
                        graph[node.Item2][i], node.Item3 + 1);

                    if (filter[tuple.Item1, tuple.Item2] == 1)
                        continue;
                    myQueue.Enqueue(tuple);
                    filter[tuple.Item1, tuple.Item2] = 1;
                }
            }
            
            myQueue1 = myQueue;
        }
        
        return 0;
    }
}