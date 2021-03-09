using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Add_One_Row_to_Tree
{
    public class Add_One_Row_to_Tree
    {
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (root == null) return root;

            if (d == 1) return new TreeNode(v, root);

            if (d == 2)
            {
                var temp = root.left;
                root.left = new TreeNode(v, temp);

                temp = root.right;
                root.right = new TreeNode(v, null, temp);
                
                return root;
            }

            AddOneRow(root.left, v, d - 1);
            AddOneRow(root.right, v, d - 1);

            return root;
        }
    }
}
