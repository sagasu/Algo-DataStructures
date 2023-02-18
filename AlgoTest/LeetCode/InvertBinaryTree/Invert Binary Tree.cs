using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.InvertBinaryTree
{
    public class Invert_Binary_Tree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var inverted = new TreeNode(root.val);
            InvertTree(root, inverted);
            return inverted;
        }

        void InvertTree(TreeNode original, TreeNode inverted)
        {
            if (original.left != null)
            {
                inverted.right = new TreeNode(original.left.val);
                InvertTree(original.left, inverted.right);
            }

            if (original.right != null)
            {
                inverted.left = new TreeNode(original.right.val);
                InvertTree(original.right, inverted.left);
            }
        }
    }
}
