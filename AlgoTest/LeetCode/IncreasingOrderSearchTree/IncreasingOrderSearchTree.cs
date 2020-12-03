using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.IncreasingOrderSearchTree
{
    [TestClass]
    public class IncreasingOrderSearchTree
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode(5, new TreeNode(1), new TreeNode(7));
            IncreasingBST(t);
        }

        public TreeNode IncreasingBST(TreeNode root)
        {
            BST(root);
            return head;
        }

        TreeNode tree;
        TreeNode head;

        public void BST(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                
            }

            if(root.left != null)
                BST(root.left);

            if (tree == null)
            {
                tree = new TreeNode();
                head = tree;
            }
            else
            {
                tree.right = new TreeNode();
                tree = tree.right;
            }

            tree.val = root.val;

            if(root.right != null)
                BST(root.right);
        }
    }
}
