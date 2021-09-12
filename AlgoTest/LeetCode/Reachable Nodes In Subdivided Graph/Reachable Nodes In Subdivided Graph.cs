using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Reachable_Nodes_In_Subdivided_Graph
{
    class Reachable_Nodes_In_Subdivided_Graph
    {
        public int ReachableNodes(int[][] edges, int maxMoves, int n)
        {
            var res = 0;
            var node2Remains = new int[n];
            var visited = new bool[n];
            var distance = new int[n, n];
            var edgeOccupied = new int[n, n];
            var graph = new IList<int>[n];

            for (var i = 0; i < n; i++)
            {
                node2Remains[i] = -1;
                graph[i] = new List<int>();
            }

            foreach (var t in edges)
            {
                var v1 = t[0];
                var v2 = t[1];
                graph[v1].Add(v2);
                graph[v2].Add(v1);
                distance[v1, v2] = t[2];
                distance[v2, v1] = t[2];
            }

            var queue = new Queue<(int node, int remains)>();
            (int node, int remains) start = (0, maxMoves);

            queue.Enqueue(start);
            node2Remains[0] = maxMoves;

            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                visited[curr.node] = true;

                var children = graph[curr.node];

                foreach (var child in children)
                {
                    var dis = distance[curr.node, child];
                    if (curr.remains >= dis)
                    {
                        edgeOccupied[curr.node, child] = dis;

                        var newRemainMove = curr.remains - dis - 1;
                        if (newRemainMove > node2Remains[child])
                        {
                            (int node, int remains) next = (child, newRemainMove);
                            node2Remains[child] = newRemainMove;
                            queue.Enqueue(next);
                        }
                    }
                    else
                    {
                        edgeOccupied[curr.node, child] = Math.Max(edgeOccupied[curr.node, child], curr.remains);
                    }
                }
            }

            for (var i = 0; i < edges.Length; i++)
            {
                var v1 = edges[i][0];
                var v2 = edges[i][1];
                var occupied = Math.Min(edges[i][2], edgeOccupied[v1, v2] + edgeOccupied[v2, v1]);
                res += occupied;
            }

            for (var i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    res++;
                }
            }

            return res;
        }
    }
}
