using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Min_Cost_to_Connect_All_Points
{
    internal class Min_Cost_to_Connect_All_Points
    {
        public int MinCostConnectPoints(int[][] points)
        {
            var dict = new Dictionary<int, int>();

            if (points == null || points.Length == 0) return 0;
            
            var size = points.Length;
            var edges = new List<Edge>();

            for (var i = 0; i < size; i++)
            {
                var coordinate1 = points[i];
                for (var j = i + 1; j < size; j++)
                {
                    var coordinate2 = points[j];
                    var cost = Math.Abs(coordinate1[0] - coordinate2[0]) + Math.Abs(coordinate1[1] - coordinate2[1]);
                    var edge = new Edge(i, j, cost);
                    edges.Add(edge);
                }
            }

            edges.Sort((x, y) => x.cost - y.cost);

            var result = 0;
            var count = size - 1;

            foreach (var edge in edges)
            {
                int group1 = Find(edge.point1, dict), group2 = Find(edge.point2, dict);
                if (group1 != group2)
                {
                    result += edge.cost;
                    dict[group1] = group2;
                }
            }
            return result;
        }

        public class Edge
        {
            public int point1;
            public int point2;
            public int cost;

            public Edge(int point1, int point2, int cost)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.cost = cost;
            }
        }

        private int Find(int x, Dictionary<int, int> dict)
        {
            if (!dict.ContainsKey(x)) dict[x] = x;
            if (dict[x] != x) dict[x] = Find(dict[x], dict);
            return dict[x];
        }
    }
}
