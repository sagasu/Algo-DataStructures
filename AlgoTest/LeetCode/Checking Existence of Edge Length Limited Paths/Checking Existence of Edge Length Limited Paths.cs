using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Checking_Existence_of_Edge_Length_Limited_Paths
{
    internal class Checking_Existence_of_Edge_Length_Limited_Paths
    {
        public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            var edgesCount = edgeList.Length;
            var queriesCount = queries.Length;
            var dsu = new DSU(n);

            for (var i = 0; i < queriesCount; i++)
                queries[i] = new[] { queries[i][0], queries[i][1], queries[i][2], i };

            Array.Sort(queries, (a, b) => a[2] - b[2]);
            Array.Sort(edgeList, (a, b) => a[2] - b[2]);

            var res = new bool[queriesCount];

            for (int i = 0, j = 0; i < queriesCount; i++)
            {
                while (j < edgesCount && edgeList[j][2] < queries[i][2])
                    dsu.Union(edgeList[j][0], edgeList[j++][1]);

                res[queries[i][3]] = dsu.Find(queries[i][0]) == dsu.Find(queries[i][1]);
            }

            return res;
        }

        class DSU
        {
            private readonly int[] _parent;

            public DSU(int n)
            {
                _parent = new int[n];

                for (var i = 0; i < n; i++) _parent[i] = i;
            }

            public int Find(int x)
            {
                _parent[x] = _parent[x] != x ? Find(_parent[x]) : x;
                return _parent[x];
            }

            public void Union(int x, int y) => _parent[Find(x)] = _parent[Find(y)];

        }

    }
}
