using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Path_Sum_II
{
    internal class Path_Sum_II
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            var result = new List<IList<int>>();
            DFS(root, result, new List<int>(), 0, targetSum);
            return result;
        }

        public void DFS(TreeNode root, IList<IList<int>> result, List<int> temp, int sum, int target)
        {
            if (root == null)
                return;

            var ttemp = temp.ToList();
            ttemp.Add(root.val);
            sum += root.val;

            if (root.left == null && root.right == null)
            {
                if (sum == target)
                    result.Add(ttemp);
                return;
            }

            DFS(root.left, result, ttemp, sum, target);
            DFS(root.right, result, ttemp, sum, target);
        }
    }
}
