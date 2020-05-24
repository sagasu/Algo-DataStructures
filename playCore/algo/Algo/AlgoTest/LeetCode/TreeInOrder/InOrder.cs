using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.TreeInOrder
{
    class InOrder
    {
        List<int> orderPrint = new List<int>();

        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return orderPrint;

            if (root.left != null)
                InorderTraversal(root.left);

            orderPrint.Add(root.val);

            if (root.right != null)
                InorderTraversal(root.right);

            return orderPrint;
        }
    }
}
