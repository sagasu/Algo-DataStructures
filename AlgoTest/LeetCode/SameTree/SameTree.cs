using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.SameTree
{
    public class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null || q == null)
                return false;

            return IsSameTree2(p, q);

        }

        private bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if ((p.left == null && q.left != null) || (p.left != null && q.left == null) || (p.right != null && q.right == null) || (p.right == null && q.right != null))
                return false;

            if (p.left != null && q.left != null)
            {
                if (!IsSameTree(p.left, q.left))
                    return false;
            }

            if (p.val != q.val)
                return false;

            if (p.right != null && q.right != null)
            {
                if (!IsSameTree(p.right, q.right))
                    return false;
            }

            return true;
        }
    }
}
