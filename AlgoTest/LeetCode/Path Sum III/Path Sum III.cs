using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Path_Sum_III
{
    class Path_Sum_III
    {
        public int PathSum(TreeNode root, int sum, bool start = true)
        {
            if (root == null) return 0;

            var count = PathSum(root.left, sum - root.val, false) + PathSum(root.right, sum - root.val, false);

            if (start)
            {
                count += PathSum(root.left, sum, true) + PathSum(root.right, sum, true);
            }

            if (sum - root.val == 0) count++;

            return count;
        }
    }
}
