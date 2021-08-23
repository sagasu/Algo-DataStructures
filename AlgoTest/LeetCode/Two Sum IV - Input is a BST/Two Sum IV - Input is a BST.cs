using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Two_Sum_IV___Input_is_a_BST
{
    public class Two_Sum_IV___Input_is_a_BST
    {
        IList<int> elements = new List<int>();
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;

            if(elements.Any(x => x + root.val == k)) return true;
            elements.Add(root.val);

            if(FindTarget(root.left, k)) return true;
            if(FindTarget(root.right, k)) return true;
            return false;
        }
    }
}
