using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.MaximumDepthofBinaryTree
{
    public class MaximumDepth
    {
        public int MaxDepth(TreeNode root)
        {
            return MaxDepthBottomUp(root);

            MaxDepthTopDown(root, 0);
        }

        // much simpler and no need for external variable.
        int MaxDepthBottomUp(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.right), MaxDepth(root.left)) + 1;
        }

        private int maxDepth;

        int MaxDepthTopDown(TreeNode root, int level)
        {
            if (root == null)
                return level;

            maxDepth = Math.Max(MaxDepthTopDown(root.left, level + 1), maxDepth);
            maxDepth = Math.Max(MaxDepthTopDown(root.right, level + 1), maxDepth);
            return maxDepth;
        }
    }
}
