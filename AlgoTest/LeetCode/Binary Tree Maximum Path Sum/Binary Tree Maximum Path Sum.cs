using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Binary_Tree_Maximum_Path_Sum
{
    internal class Binary_Tree_Maximum_Path_Sum
    {
        int mx;
        public int MaxPathSum(TreeNode root)
        {
            mx = int.MinValue;
            MaxPath(root);
            return mx;
        }

        private int MaxPath(TreeNode root)
        {
            if (root is null)
                return 0;
            int left = Math.Max(0, MaxPath(root.left));
            int right = Math.Max(0, MaxPath(root.right));
            mx = Math.Max(mx, left + right + root.val);
            return Math.Max(left, right) + root.val;
        }
    }
}
