using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.InvertBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var inverted = new TreeNode();
            InvertTree(root, inverted);
            return inverted;
        }

        public void InvertTree(TreeNode original, TreeNode inverted)
        {
            inverted.val = original.val;
            
            if (original.left != null)
            {
                inverted.right = new TreeNode();
                InvertTree(original.left, inverted.right);
            }

            if (original.right != null)
            {
                inverted.left = new TreeNode();
                InvertTree(original.right, inverted.left);
            }
            
        }
    }
}
