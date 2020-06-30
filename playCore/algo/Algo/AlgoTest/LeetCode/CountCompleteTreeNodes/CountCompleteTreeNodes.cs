using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.CountCompleteTreeNodes
{
    public class CountCompleteTreeNodes
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            return GetNumberOfNodes(root, 0);
        }

        private int GetNumberOfNodes(TreeNode root, int index)
        {
            var left = 0;
            var right = 0;

            if (root.left != null)
            {
                if (root.right == null)
                    return root.left.val;

                left = GetNumberOfNodes(root.left, index + 1);
            }

            if (root.right != null)
                right = GetNumberOfNodes(root.right, index + 1);

            return Math.Max(root.val, Math.Max(left, right));


        }
    }
}
