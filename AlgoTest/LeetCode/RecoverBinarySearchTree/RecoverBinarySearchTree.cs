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

            //var t = new TreeNode(3, new TreeNode(1), new TreeNode(4, new TreeNode(2)));
            //RecoverTree(t);

            var t = new TreeNode(5, new TreeNode(3, new TreeNode(-2147483648), new TreeNode(2)), new TreeNode(9));
            RecoverTree(t);
        }

        // This is a recursive solution and space complexity is not O(1) :(
        // Space complexity here is O(logN) or O(n) depending on how memory is implemented - do we count stack or heap allocation.
        //There are exactly two nodes that were swapped
        public void RecoverTree(TreeNode root)
        {
            if (root == null) return;

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

            if (first == null && previous.val > root.val) first = previous;
            

            if (first != null && previous.val > root.val) second = root;
            
            previous = root;

            InOrderTraverse(root.right);
        }

    }
}
