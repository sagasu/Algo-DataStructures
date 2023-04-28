using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Similar_String_Groups
{
    public class Similar_String_Groups
    {
        public int NumSimilarGroups(string[] strs)
        {
            var visited = new bool[strs.Length];
            var res = 0;

            for (var i = 0; i < strs.Length; i++)
                if (!visited[i])
                {
                    res++;
                    DFS(strs, visited, i);
                }
            
            return res;
        }

        private static bool IsSimilar(string s1, string s2)
        {
            var diff = s1.Where((t, i) => t != s2[i]).Count();

            return diff is 2 or 0;
        }

        private void DFS(string[] strs, bool[] visited, int index)
        {
            visited[index] = true;
            var curr = strs[index];

            for (var i = 0; i < strs.Length; i++)
                if (!visited[i] && IsSimilar(curr, strs[i])) DFS(strs, visited, i);
        }
    }
}
