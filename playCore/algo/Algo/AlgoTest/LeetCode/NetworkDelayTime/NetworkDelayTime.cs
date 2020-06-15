using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.NetworkDelayTime
{
    [TestClass]
    public class NetworkDelayTimeProblem
    {
        [TestMethod]
        public void Test() {
            var t = new int[][] { new int[]{ 2, 1, 1 }, new int[]{ 2, 3, 1 }, new int[] { 3, 4, 1 } };
            Assert.AreEqual(2, NetworkDelayTime(t, 4, 2));
        }

        Dictionary<int, Dictionary<int, int>> adj = new Dictionary<int, Dictionary<int, int>>();

        public int NetworkDelayTime(int[][] times, int N, int K)
        {

            for (var i = 0; i < times.Length; i++) {
                var src = times[i][0];
                if (adj.ContainsKey(src))
                {
                    adj[src].Add(times[i][1], times[i][2]);
                }
                else {
                    adj[src] = new Dictionary<int, int> { { times[i][1], times[i][2] } };
                }
            }
            return Dijkstra(K, N);
        }

        public int Dijkstra(int k, int n) {
            var minCost = new int[n+1];
            Array.Fill(minCost, int.MaxValue);

            Queue<int> queue = new Queue<int>();
            minCost[k] = 0;
            queue.Enqueue(k);

            while (queue.Count > 0) {
                var src = queue.Dequeue();

                if (!adj.ContainsKey(src))
                    continue;

                foreach (var key in adj[src].Keys) {
                    var cost = minCost[src] + adj[src][key];

                    if (cost < minCost[key])
                    {
                        minCost[key] = cost;
                        queue.Enqueue(key);
                    }
                }
            }

            var maxCost = int.MinValue;
            for (var i = 1; i < minCost.Length; i++) {
                if (minCost[i] == int.MaxValue)
                    return -1;

                if (minCost[i] > maxCost)
                    maxCost = minCost[i];
            }
            return maxCost;
        }
    }
}
