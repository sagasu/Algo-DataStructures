using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Path_with_Maximum_Probability
{
    [TestClass]
    public class Path_with_Maximum_Probability
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(0.25,
            MaxProbability(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 0, 2 } },
                new[] { 0.5, 0.5, 0.2 }, 0, 2));

        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            var dic = new Dictionary<int, List<double[]>>();
            
            for (var i = 0; i < n; i++)
                dic[i] = new List<double[]>();
            
            for (var i = 0; i < edges.Length; i++)
            {
                dic[edges[i][0]].Add(new double[] { edges[i][1], succProb[i] });
                dic[edges[i][1]].Add(new double[] { edges[i][0], succProb[i] });
            }

            var prob = new double[n];
            prob[start] = 1.0;

            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var currVertex = queue.Dequeue();
                var currProb = prob[currVertex];

                foreach (var next in dic[currVertex])
                {
                    var nextProb = currProb * next[1];
                    if (prob[(int)next[0]] < nextProb)
                    {
                        prob[(int)next[0]] = nextProb;
                        queue.Enqueue((int)next[0]);
                    }
                }
            }

            return prob[end];
        }
    }
}
