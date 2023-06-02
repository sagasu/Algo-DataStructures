using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Detonate_the_Maximum_Bombs
{
    internal class Detonate_the_Maximum_Bombs
    {
        int DFS(IList<IList<int>> bombInRangeNodes, int i, bool[] isDetonated)
        {
            if (isDetonated[i]) return 0;

            isDetonated[i] = true;
            var count = 1;

            foreach (var bombNode in bombInRangeNodes[i]) count += DFS(bombInRangeNodes, bombNode, isDetonated);

            return count;
        }

        public int MaximumDetonation(int[][] bombs)
        {
            var bombInRangeNodes = new List<IList<int>>();
            var max = 1;

            for (var i = 0; i < bombs.Length; i++)
            {
                var detonatedBombs = new List<int>();

                for (var j = 0; j < bombs.Length; j++)
                {
                    var x = bombs[j][0] - bombs[i][0];
                    var y = bombs[j][1] - bombs[i][1];
                    var dis = Math.Sqrt(Math.Pow(y, 2) + Math.Pow(x, 2));
                    if (dis <= bombs[i][2]) detonatedBombs.Add(j);
                    
                }

                bombInRangeNodes.Add(detonatedBombs);
            }

            for (var i = 0; i < bombs.Length; i++)
            {
                var isDetonated = new bool[bombs.Length];
                max = Math.Max(max, DFS(bombInRangeNodes, i, isDetonated));
            }

            return max;
        }

        
    }
}
