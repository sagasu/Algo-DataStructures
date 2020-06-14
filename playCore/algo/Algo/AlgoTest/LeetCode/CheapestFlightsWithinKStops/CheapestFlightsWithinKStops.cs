using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AlgoTest.LeetCode.CheapestFlightsWithinKStops
{
    class CheapestFlightsWithinKStops
    {
        Dictionary<int, IList<ValueTuple<int, int>>> adj = new Dictionary<int, IList<ValueTuple<int, int>>>();
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var comp = new NodeComparer();
            var sl = new SortedSet<Node>(comp);
            for (var i = 0; i < flights.Length; i++) {
                var sr = flights[i][0];
                if (adj.ContainsKey(sr))
                {
                    adj[sr].Add((flights[i][1], flights[i][2]));
                }
                else {
                    adj[sr] = new List<ValueTuple<int, int>> { (flights[i][1], flights[i][2]) };
                }
            }

            sl.Add(new Node(src, 0, -1));

            while (sl.Count > 0) {
                var curr = sl.First();
                sl.Remove(curr);


                if (curr.Src == dst)
                    return curr.Cost;

                if (curr.Stop < K) {
                    var nexts = adj.GetValueOrDefault(curr.Src);
                    if (nexts != null)
                    {
                        foreach (var next in nexts)
                        {
                            sl.Add(new Node(next.Item1, curr.Cost + next.Item2, curr.Stop + 1));
                        }
                    }
                }

                
            }
            return -1;
        }

        class Node {
            public Node(int src, int cost, int stop)
            {
                Src = src;
                Cost = cost;
                Stop = stop;
            }

            public int Src { get; }
            public int Cost { get; }
            public int Stop { get; }
        }

        class NodeComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return x.Cost - y.Cost;
            }
        }

        void DFS(int index, int dst, int k, int cost) {
            for (var i = 0; i < adj[index].Count; i++) {
                DFS(adj[index][i].Item1, dst, k, cost + adj[index][i].Item2);
            }
        }
    }
}
