using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FriendCircle
{
    class FriendCircle
    {
        HashSet<int> seen = new HashSet<int>();
        private int count = 0;
        public int FindCircleNum(int[][] M)
        {
            for (var i = 0; i < M.Length; i++)
            {
                if (!seen.Contains(i))
                {
                    count += 1;
                    SearchDFS(i, M);
                }
            }

            return count;
        }

        private void SearchDFS(int i, int[][] M)
        {
            seen.Add(i);
            
            for(var j =0;j < M[i].Length;j++)
            {
                if(M[i][j] == 1 && !seen.Contains(j))
                    SearchDFS(j, M);
            }
        }
    }
}
