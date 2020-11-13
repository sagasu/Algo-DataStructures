using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.UnionFind
{
    class UnionFind
    {
        public int[] parent;

        public int Find(int i)
        {
            if (parent[i] == -1)
                return i;

            return Find(parent[i]);
        }

        public void Union(int i, int j)
        {
            var parentI = Find(i);
            var parentJ = Find(j);

            
            parent[parentI] = parentJ;
        }

        public bool isCycle(int[][] typicalEdgeStructure)
        {
            for (var i = 0; i < typicalEdgeStructure.Length; i++)
            {
                var parentI = Find(i);
                for (var j = i; i < typicalEdgeStructure[i].Length; j++)
                {
                    var parentJ = Find(j);
                    if (parentI == parentJ)
                        return true;

                    Union(parentI, parentJ);
                }
            }

            return false;
        }

        public void init()
        {
            var typicalEdgeStructure = new int[][]
            {
                new int[] {1, 1, 0},
                new int[] {1, 1, 0},
                new int[] {0, 0, 1}
            };

            parent = new int[typicalEdgeStructure.Length];
            //create parent structure
            for(var i = 0; i<typicalEdgeStructure.Length;i++)
            {
                parent[i] = -1;
            }

            //perform operation on union find structure
            isCycle(typicalEdgeStructure);
        }
    }
}
