using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.House_Robber_III
{
    public class House_Robber_III
    {
        public int Rob(TreeNode root)
        {
            var arr = DFS(root);
            return Math.Max(arr[0], arr[1]);
        }

        private int[] DFS(TreeNode node)
        {
            if (node == null) return new int[2];
            
            var left = DFS(node.left);
            var right = DFS(node.right);
            var ret = new int[2];

            ret[0] = left.Max() + right.Max(); 
            ret[1] = node.val + left[0] + right[0]; 
            return ret;
        }
    }
}
