using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Binary_Tree_Inorder_Traversal
{
    internal class Binary_Tree_Inorder_Traversal
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
