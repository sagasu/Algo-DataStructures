using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SymetricTree
{
    class SymetricTree
    {
        public List<int> inOrder = new List<int>();
        public List<int> symetricInOrder = new List<int>();

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            TraverseInOrder(root);
            TraverseInSymOrder(root);
            for (var i = 0; i < inOrder.Count; i++)
            {
                if (inOrder[i] != symetricInOrder[i])
                    return false;
            }

            return true;
        }

        private void TraverseInOrder(TreeNode root)
        {
            inOrder.Add(root.val);

            if(root.left != null)
                TraverseInOrder(root.left);

            if (root.right != null)
                TraverseInOrder(root.right);
        }

        private void TraverseInSymOrder(TreeNode root)
        {
            symetricInOrder.Add(root.val);

            if (root.right != null)
                TraverseInSymOrder(root.right);

            if (root.left != null)
                TraverseInSymOrder(root.left);
        }
    }
}
