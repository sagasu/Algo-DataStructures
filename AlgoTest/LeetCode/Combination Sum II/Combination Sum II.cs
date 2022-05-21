using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Combination_Sum_II
{
    internal class Combination_Sum_II
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            Array.Sort(candidates);
            dfs(0, target, new List<int>(), res, candidates);
            return res;
        }

        private void dfs(int idx, int target, List<int> curr, List<IList<int>> res, int[] candidates)
        {
            if (target == 0) res.Add(new List<int>(curr));
            else {
                for (var i = idx; i < candidates.Length; i++)
                {
                    if (i > idx && candidates[i - 1] == candidates[i]) continue;
                    if (target - candidates[i] < 0) break;
                    curr.Add(candidates[i]);
                    dfs(i + 1, target - candidates[i], curr, res, candidates);
                    curr.RemoveAt(curr.Count - 1);
                }
            }
        }
    }
}
