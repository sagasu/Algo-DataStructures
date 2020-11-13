using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.RedundantConnection
{
    [TestClass]
    public class RedundantConnection
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[][] {
                new []{
                    1, 2
                },
                new[]{
                    1, 3
                },
                new []{
                    2, 3
                }
            };
            //var t = new int[][] {new[] {1, 4}, new[] {3, 4}, new[] {1, 3}, new[] {1, 2}, new[] {4, 5}};
            Assert.AreEqual(new int[] { 2, 3 }, FindRedundantConnection(t));
            //Assert.AreEqual(new int[]{1,3}, FindRedundantConnection(t));
        }

        int[] parent;

        public int Find(int i)
        {
            if (parent[i] == i)
                return i;

            return Find(parent[i]);
        }

        public bool Union(int i, int j)
        {
            var parentI = Find(i);
            var parentJ = Find(j);
            

            if (parentI == parentJ)
                return false;
            
            parent[parentI] = parentJ;
            return true;
        }

        
        public int[] FindRedundantConnection(int[][] edges)
        {
            int[] ret = new int[2];
            parent = new int[edges.Length+1];
            for (int i = 0; i < edges.Length+1; i++)
            {
                parent[i] = i;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                if (!Union(edges[i][0], edges[i][1]))
                {
                    ret = edges[i];
                    return ret;
                }
            }

            return ret;
        }
    }
}
