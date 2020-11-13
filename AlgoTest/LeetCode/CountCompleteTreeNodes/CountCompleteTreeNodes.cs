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
            var sum = 0;

            if (root.left != null)
            {
                sum += GetNumberOfNodes(root.left, index + 1);
            }

            sum += 1;

            if (root.right != null)
                sum += GetNumberOfNodes(root.right, index + 1);

            return sum;
        }
    }
}
