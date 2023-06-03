using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Time_Needed_to_Inform_All_Employees
{
    internal class Time_Needed_to_Inform_All_Employees
    {
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            var empTree = new List<int>[n];
            for (var i = 0; i < n; ++i)
                empTree[i] = new List<int>();

            for (var i = 0; i < n; ++i)
            {
                if (manager[i] == -1) continue;
                
                empTree[manager[i]].Add(i);
            }

            return DFS(headID, -1);

            int DFS(int node, int parent)
            {
                var ans = informTime[node];
                var toAdd = 0;

                foreach (var child in empTree[node])
                    if (child != parent)
                        toAdd = Math.Max(toAdd, DFS(child, node));

                return ans + toAdd;
            }
        }

        
    }
}
