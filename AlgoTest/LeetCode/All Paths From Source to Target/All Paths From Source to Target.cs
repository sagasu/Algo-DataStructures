using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.All_Paths_From_Source_to_Target
{
    [TestClass]
    public class All_Paths_From_Source_to_Target
    {
        [TestMethod]
        public void Test() => Assert.IsTrue(AllPathsSourceTarget(new int[][]{new int[]{1, 2},new int[]{3}, new int[]{3}, new int[]{}}) is [[0, 1, 3], [0,2,3]]);


        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var paths = new List<IList<int>>();

            void DFS(List<int> path, int nodeIndx)
            {
                if (nodeIndx == graph.Length-1)
                {
                    paths.Add(new List<int>(path));
                    return;
                }

                for (var i = 0; i < graph[nodeIndx].Length; i++)
                {
                    path.Add(graph[nodeIndx][i]);
                    DFS(path, graph[nodeIndx][i]);
                    path.RemoveAt(path.Count - 1);
                }
            }

            DFS(new List<int>(){0}, 0);
            return paths;
        }
    }
}
