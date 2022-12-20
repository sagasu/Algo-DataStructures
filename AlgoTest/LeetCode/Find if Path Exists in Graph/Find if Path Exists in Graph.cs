using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Find_if_Path_Exists_in_Graph
{
    internal class Find_if_Path_Exists_in_Graph
    {
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            if (start == end) return true;

            int lastCount = 0;

            var startReaches = new bool[n];
            startReaches[start] = true;

            var endReaches = new bool[n];
            endReaches[end] = true;

            int reachCount = 2;

            while (reachCount > lastCount)
            {
                lastCount = reachCount;
                for (int i = 0; i < edges.Length; i++)
                {
                    int edgeZero = edges[i][0];
                    int edgeOne = edges[i][1];

                    if ((startReaches[edgeZero]) && (!startReaches[edgeOne]))
                    {
                        startReaches[edgeOne] = true;
                        reachCount++;
                    }
                    if ((startReaches[edgeOne]) && (!startReaches[edgeZero]))
                    {
                        startReaches[edgeZero] = true;
                        reachCount++;
                    }

                    if ((endReaches[edgeZero]) && (!endReaches[edgeOne]))
                    {
                        endReaches[edgeOne] = true;
                        reachCount++;
                    }
                    if ((endReaches[edgeOne]) && (!endReaches[edgeZero]))
                    {
                        endReaches[edgeZero] = true;
                        reachCount++;
                    }
                    if ((startReaches[edgeZero] && endReaches[edgeZero]) ||
                        (startReaches[edgeOne] && endReaches[edgeOne])) return true;
                }
            }

            return false;
        }
    }
}
