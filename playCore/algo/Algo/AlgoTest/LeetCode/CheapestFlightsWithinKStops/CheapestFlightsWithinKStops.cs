using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AlgoTest.LeetCode.CheapestFlightsWithinKStops
{
    // Not working for some cases because SortedSet is not really a heap
    [TestClass]
    public class CheapestFlightsWithinKStops
    {
        [TestMethod]
        public void Test() {
            var t = new int[][] { new int[] { 3, 4, 7 }, new int[] { 6, 2, 2 }, new int[] { 0, 2, 7 }, new int[] { 0, 1, 2 }, new int[] { 1, 7, 8 }, new int[] { 4, 5, 2 }, new int[] { 0, 3, 2 }, new int[] { 7, 0, 6 }, new int[] { 3, 2, 7 }, new int[] { 1, 3, 10 }, new int[] { 1, 5, 1 }, new int[] { 4, 1, 6 }, new int[] { 4, 7, 5 }, new int[] { 5, 7, 10 } };

            var ret = FindCheapestPrice(8, t, 4, 3, 7);
            Assert.AreEqual(13, ret);
        }

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
