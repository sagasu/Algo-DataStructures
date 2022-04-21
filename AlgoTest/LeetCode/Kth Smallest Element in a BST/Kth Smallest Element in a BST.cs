using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Kth_Smallest_Element_in_a_BST
{
    internal class Kth_Smallest_Element_in_a_BST
    {
        List<int> list;
        public int KthSmallest(TreeNode root, int k)
        {
            list = new List<int>(); //List to hold values in the increasing order
            InOrder(root);          //InOrder to get values in increasing order
            return list[k - 1];       //Get kth element as k starts from 1
        }

        private void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.left);
                list.Add(root.val);
                InOrder(root.right);
            }
        }
    }
}
