using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.RecoverBinarySearchTree
{
    [TestClass]
    public class RecoverBinarySearchTree
    {
        [TestMethod]
        public void Test()
        {
            //var t = new TreeNode(1, new TreeNode(3, null, new TreeNode(2)));
            //RecoverTree(t);
            
            var t = new TreeNode(3, new TreeNode(1), new TreeNode(4, new TreeNode(2)));
            RecoverTree(t);
        }
        //There are exactly two nodes that were swapped
        public void RecoverTree(TreeNode root)
        {
            if (root == null)
                return;

            InOrderTraverse(root);

            var temp = first.val;
            first.val = second.val;
            second.val = temp;
        }

        private TreeNode first;
        private TreeNode second;
        private TreeNode previous = new TreeNode(Int32.MinValue);

        private void InOrderTraverse(TreeNode root)
        {
            if (root == null)
                return;

            InOrderTraverse(root.left);

            if (root.val <= previous.val)
            {
                StoreRoot(previous, root);
                StoreRoot(previous, root);
            }

            previous = root;
            InOrderTraverse(root.right);
        }

        private void StoreRoot(TreeNode node, TreeNode child)
        {
            if (first == null)
            {
                first = node;
            }
            else
            {
                second = child;
            }
            
        }
    }
}
