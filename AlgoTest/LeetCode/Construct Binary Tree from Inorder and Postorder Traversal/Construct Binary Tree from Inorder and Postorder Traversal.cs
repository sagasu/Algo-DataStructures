using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
{
    class Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {

            if (inorder.Length != postorder.Length) return null;
            if (inorder.Length == 0 && postorder.Length == 0) return null;
            if (inorder.Length == 1 && postorder.Length == 1)
                return new TreeNode(postorder[postorder.Length - 1]);
            

            var root = new TreeNode(postorder[postorder.Length - 1]);
            var rootIndexInorder = Array.IndexOf(inorder, root.val);

            //Left sub-tree in-order
            var lSubIn = new int[rootIndexInorder];
            Array.Copy(inorder, 0, lSubIn, 0, rootIndexInorder);

            //Right sub-tree in-order
            var rSubIn = new int[inorder.Length - lSubIn.Length - 1];
            Array.Copy(inorder, lSubIn.Length + 1, rSubIn, 0, inorder.Length - lSubIn.Length - 1);

            //Left sub-tree post-order
            var lSubPost = new int[lSubIn.Length];
            Array.Copy(postorder, 0, lSubPost, 0, lSubIn.Length);

            //Right sub-tree post-order
            var rSubPost = new int[rSubIn.Length];
            Array.Copy(postorder, lSubIn.Length, rSubPost, 0, rSubIn.Length);

            root.left = BuildTree(lSubIn, lSubPost);
            root.right = BuildTree(rSubIn, rSubPost);

            return root;
        }
    }
}
