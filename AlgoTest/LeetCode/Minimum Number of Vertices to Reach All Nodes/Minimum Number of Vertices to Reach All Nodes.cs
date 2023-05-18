using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Minimum_Number_of_Vertices_to_Reach_All_Nodes
{
    internal class Minimum_Number_of_Vertices_to_Reach_All_Nodes
    {
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            var result = Enumerable.Range(0, n).ToHashSet();

            foreach (var edge in edges)
                if (result.Contains(edge[1]))
                    result.Remove(edge[1]);
                
            return result.ToArray();
        }
    }
}
