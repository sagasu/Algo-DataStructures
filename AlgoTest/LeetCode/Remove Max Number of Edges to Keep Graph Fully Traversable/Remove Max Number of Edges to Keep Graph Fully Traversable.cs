using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Remove_Max_Number_of_Edges_to_Keep_Graph_Fully_Traversable
{
    internal class Remove_Max_Number_of_Edges_to_Keep_Graph_Fully_Traversable
    {
        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            var res = 0;
            var alice = new UnionFind(n);
            var bob = new UnionFind(n);

            foreach (var edge in edges)
                if (edge[0] == 3 && (!alice.Union(edge[1], edge[2]) || !bob.Union(edge[1], edge[2])))
                    res++;
            
            foreach (var edge in edges)
            {
                if (edge[0] == 1 && !alice.Union(edge[1], edge[2])) res++;
                if (edge[0] == 2 && !bob.Union(edge[1], edge[2])) res++;
            }

            return alice.Componets == 1 && bob.Componets == 1 ? res : -1;
        }

        class UnionFind
        {
            private readonly int[] _parent;
            public int Componets { get; private set; }
            public UnionFind(int n)
            {
                Componets = n;
                _parent = new int[n + 1];
                for (int i = 0; i <= n; i++)
                {
                    _parent[i] = i;
                }
            }

            int Find(int x)
            {
                if (_parent[x] != x) _parent[x] = Find(_parent[x]);
                return _parent[x];
            }

            public bool Union(int x, int y)
            {
                var px = Find(x);
                var py = Find(y);

                if (px != py)
                {
                    _parent[px] = py;
                    Componets--;
                    return true;
                }

                return false;
            }
        }
    }
}
