using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Diameter_of_Binary_Tree
{
    class Diameter_of_Binary_Tree
    {
        int maxDiameter;

        public int Depth(TreeNode node)
        {
            if (node == null) return 0;

            var leftDepth = Depth(node.left);
            var rightDepth = Depth(node.right);
            var diameter = leftDepth + rightDepth;

            maxDiameter = Math.Max(diameter, maxDiameter);
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Depth(root);
            return maxDiameter;
        }
    }
}
