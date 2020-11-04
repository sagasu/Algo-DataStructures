using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MinimumHeightTrees
{
    [TestClass]
    public class MinimumHeightTrees
    {
        [TestMethod]
        public void Test()
        {
            var t = new int [][]{new int []{3, 0}, new int []{3, 1}, new int []{3, 2}, new int []{3, 4}, new int []{5, 4}};
            CollectionAssert.AreEqual(new int[]{3,4}, FindMinHeightTrees(6,t).ToList());
        }

        
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if(n <= 0) return new List<int>();
            if(n == 1)
                return new List<int>(){0};

            var adj = new Dictionary<int, List<int>>();
            var edgesCount = new int[n];


            for (var i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }

            for (var i = 0; i < edges.Length; i++)
            {
                edgesCount[edges[i][0]] += 1;
                edgesCount[edges[i][1]] += 1;
                adj[edges[i][0]].Add(edges[i][1]);
                adj[edges[i][1]].Add(edges[i][0]);
            }

            var queue= new Queue<int>();
            for (var i = 0; i < n; i++)
            {
                if(edgesCount[i] == 1)
                    queue.Enqueue(i);
            }

            // The trick of this problem is to realise that there can be always only up two different roots for which we have a Minimum Height Trees
            while (n > 2)
            {
                var size = queue.Count;
                n -= size;

                while (size > 0)
                {
                    var node = queue.Dequeue();

                    foreach (var neigb in adj[node])
                    {
                        edgesCount[neigb] -= 1;
                        if (edgesCount[neigb] == 1)
                            queue.Enqueue(neigb);
                    }

                    size = size - 1;
                }
            }

            var res = queue.ToArray();
            return res;
        }
        
    }
}
