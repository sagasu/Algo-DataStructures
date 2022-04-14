using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SearchinaBinarySearchTree
{
    class SearchinaBinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val == val) return root;

            if (root.val < val) return SearchBST(root.right, val);

            if (root.val > val) return SearchBST(root.left, val);

            return null;
        }
    }
}
