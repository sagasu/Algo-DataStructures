using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Lowest_Common_Ancestor_of_a_Binary_Search_Tree
{
    internal class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == p || root == q) return root;

            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            

            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            
            return root;
        }
    }
}
