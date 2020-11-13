using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.PostOrder
{
    class PostOrder
    {
        List<int> orderPrint = new List<int>();

        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null)
                return orderPrint;

            if (root.left != null)
                PostorderTraversal(root.left);

            if (root.right != null)
                PostorderTraversal(root.right);

            orderPrint.Add(root.val);
            return orderPrint;
        }
    }
}
