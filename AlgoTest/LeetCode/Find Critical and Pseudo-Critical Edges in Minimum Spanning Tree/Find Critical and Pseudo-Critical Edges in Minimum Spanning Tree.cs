using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

public class Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree
{
    internal class UnionFind
        {
            int[] parent;
            int cost;
            int setCount;
            public UnionFind(int n)
            {
                this.parent = Enumerable.Range(0, n).ToArray();
                this.cost = 0;
                this.setCount = n;
            }

            public void ProcessEdge(int[] arr)
            {
                int p1 = findParent(arr[0]);
                int p2 = findParent(arr[1]);

                if (p1 != p2)
                {
                    parent[p1] = p2;
                    setCount--;

                    cost += arr[2];
                }
            }

            private int findParent(int c)
            {
                if (parent[c] == c) return c;

                return findParent(parent[c]);

            }

            internal int GetCost()
            {
                return setCount > 1 ? int.MaxValue : cost;
            }
        }

        public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> critical = new List<int>();
            IList<int> pseudoCritical = new List<int>();

            result.Add(critical);
            result.Add(pseudoCritical);

            UnionFind uf = new UnionFind(n);

            Dictionary<int, int[]> edgeDictionary = new Dictionary<int, int[]>();

            for (int i = 0; i < edges.Length; i++)
            {
                edgeDictionary.Add(i, edges[i]);
            }

            edgeDictionary = edgeDictionary.OrderBy(x => x.Value[2]).ToDictionary(x => x.Key, x => x.Value);
            foreach (int key in edgeDictionary.Keys)
            {
                uf.ProcessEdge(edgeDictionary[key]);
            }

            int mst = uf.GetCost();

            for (int i = 0; i < edgeDictionary.Keys.Count; i++)
            {

                uf = new UnionFind(n);
                foreach (var key in edgeDictionary.Keys)
                {
                    if (key == i) continue;
                    uf.ProcessEdge(edgeDictionary[key]);
                }

                int excludeCost = uf.GetCost();
                if (excludeCost > mst)
                {
                    critical.Add(i);
                }
                else
                {
                    uf = new UnionFind(n);
                    uf.ProcessEdge(edgeDictionary[i]);

                    foreach (var key in edgeDictionary.Keys)
                    {
                        if (key == i) continue;
                        uf.ProcessEdge(edgeDictionary[key]);
                    }
                    int includeCost = uf.GetCost();
                    if (includeCost == mst)
                    {
                        pseudoCritical.Add(i);
                    }
                }
            }

            return result;
        }
}