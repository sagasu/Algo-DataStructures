using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Validate_Binary_Search_Tree
{
    internal class Validate_Binary_Search_Tree
    {
        public bool IsValidBST(TreeNode root) => DFS(root, long.MinValue, long.MaxValue);
        
        private bool DFS(TreeNode root, long min, long max)
        {
            if (root == null) return true;

            if (min < root.val && root.val < max)
            {
                var leftResult = DFS(root.left, min, root.val);
                var rightResult = DFS(root.right, root.val, max);

                if (leftResult && rightResult) return true;
            }

            return false;
        }
    }
}
