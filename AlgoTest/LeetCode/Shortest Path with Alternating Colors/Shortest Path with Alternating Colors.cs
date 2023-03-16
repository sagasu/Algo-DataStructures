using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Shortest_Path_with_Alternating_Colors
{
    internal class Shortest_Path_with_Alternating_Colors
    {
        public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            var redDic = new Dictionary<int, List<int>>();
            var blueDic = new Dictionary<int, List<int>>();
            foreach (var redEdge in redEdges)
                if (!redDic.TryAdd(redEdge[0], new List<int>{redEdge[1]})) redDic[redEdge[0]].Add(redEdge[1]);

            foreach (var blueEdge in blueEdges)
                if (!blueDic.TryAdd(blueEdge[0], new List<int> { blueEdge[1] })) blueDic[blueEdge[0]].Add(blueEdge[1]);
            // 0 blue, 1 red
            var queue = new Queue<(int node, int colour, int level)>();

            var visited = new int[n,2];
            for(var i =0;i<visited.Rank;i++)
            {
                visited[i, 0] = int.MaxValue;
                visited[i, 1] = int.MaxValue;
            }

            for(var i = 0;i < redDic[0].Count;i++)
                queue.Enqueue((redDic[0][i], 1, 1));
            
            for(var i = 0;i < blueDic[0].Count;i++)
                queue.Enqueue((blueDic[0][i], 1, 0));

            while (queue.TryDequeue(out var details))
            {
                var node = details.node;
                var colour = details.colour;
                visited[node, colour] = Math.Min(visited[node, colour], details.level);
                if(colour == 1)
                    for (var i = 0; i < blueDic[0].Count; i++)
                        queue.Enqueue((blueDic[0][i], 1, 0));
                if (colour == 0)
                    for (var i = 0; i < redDic[0].Count; i++)
                        queue.Enqueue((redDic[0][i], 1, 1));
            }

            var minPath = new int[n];
            for (var i = 0; i < n; i++)
            {
                var minBetweenColours = Math.Min(visited[i, 0], visited[i, 1]);
                if(minBetweenColours == Int32.MaxValue) minPath[i] = -1;
            }
            return minPath;

        }
    }
}
