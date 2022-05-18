using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Critical_Connections_in_a_Network
{
    public class Critical_Connections_in_a_Network
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var critCon = new List<IList<int>>();
            var graph = GetGraph(n, connections);
            var disTime = 1;
            GetDisAndLowValue(graph, 0, 0, ref disTime, new int[n], new int[n], critCon);
            return critCon;
        }

        private int GetDisAndLowValue(IList<IList<int>> graph, int node, int parent, ref int disTime, int[] dicArr, int[] lowArr, IList<IList<int>> critCon)
        {
            if (dicArr[node] != 0) return dicArr[node];

            dicArr[node] = disTime++;
            lowArr[node] = dicArr[node];

            foreach (var nd in graph[node])
            {
                if (nd == parent) continue;

                var lowV = GetDisAndLowValue(graph, nd, node, ref disTime, dicArr, lowArr, critCon);
                lowArr[node] = Math.Min(lowArr[node], lowV);

                if (dicArr[node] < lowArr[nd]) critCon.Add(new List<int> { node, nd });
            }

            return lowArr[node];
        }

        private IList<IList<int>> GetGraph(int n, IList<IList<int>> connections)
        {
            var graph = new List<IList<int>>();

            for (var i = 0; i < n; i++) graph.Add(new List<int>());

            foreach (var con in connections)
            {
                graph[con[0]].Add(con[1]);
                graph[con[1]].Add(con[0]);
            }
            return graph;
        }
    }
}
