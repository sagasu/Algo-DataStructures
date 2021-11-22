using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Delete_Node_in_a_BST
{
    class Delete_Node_in_a_BST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val > key) root.left = DeleteNode(root.left, key);
            else root.right = DeleteNode(root.right, key);

            if (root.val == key)
            {
                var right = root.right;
                root = root.left;
                root = InsertNode(root, right);
            }
            return root;
        }

        private TreeNode InsertNode(TreeNode root, TreeNode node)
        {
            if (node == null) return root;
            if (root == null) return node;
            if (root.val < node.val) root.right = InsertNode(root.right, node);
            return root;
        }
    }
}
