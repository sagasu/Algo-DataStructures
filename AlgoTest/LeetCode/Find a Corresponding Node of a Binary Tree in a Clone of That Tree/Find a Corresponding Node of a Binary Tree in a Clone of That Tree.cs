using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Find_a_Corresponding_Node_of_a_Binary_Tree_in_a_Clone_of_That_Tree
{
    internal class Find_a_Corresponding_Node_of_a_Binary_Tree_in_a_Clone_of_That_Tree
    {
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (cloned == null || target == null)
            {
                return null;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(cloned);

            while (stack.Count > 0)
            {
                var temp = stack.Pop();
                if (temp.val == target.val)
                {
                    return temp;
                }

                if (temp.left != null)
                {
                    stack.Push(temp.left);
                }

                if (temp.right != null)
                {
                    stack.Push(temp.right);
                }
            }

            return null;
        }
    }
}
