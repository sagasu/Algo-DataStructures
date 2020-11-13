using System.Collections.Generic;

namespace AlgoTest.LeetCode.TreePreOrder
{

    class PreOrder
    {
        List<int> orderPrint = new List<int>();

        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return orderPrint;

            orderPrint.Add(root.val);
            if (root.left != null)
            {
                PreorderTraversal(root.left);
            }
            if (root.right != null)
            {
                PreorderTraversal(root.right);
            }
            return orderPrint;
        }
    }
}
