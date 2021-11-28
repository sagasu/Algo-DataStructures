using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.All_Paths_From_Source_to_Target
{
    class AllPathsFromSourceToTarget
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var list = new List<IList<int>>();

            Backtrack(list, graph, new List<int> { 0 }, 0);

            return list;
        }

        private void Backtrack(List<IList<int>> list, int[][] graph, List<int> temp, int p)
        {
            if (temp.Count > 1 && temp[temp.Count - 1] == graph.Length - 1) list.Add(new List<int>(temp));

            for (var i = 0; i < graph[p].Length; i++)
            {
                temp.Add(graph[p][i]);

                Backtrack(list, graph, temp, graph[p][i]);

                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
