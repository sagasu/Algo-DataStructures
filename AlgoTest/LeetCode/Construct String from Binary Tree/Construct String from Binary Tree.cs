using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Construct_String_from_Binary_Tree
{
    internal class Construct_String_from_Binary_Tree
    {
        public string Tree2str(TreeNode root)
        {
            var str = "" + root.val;
            if (root.left != null)
                str += "(" + Tree2str(root.left) + ")";
            else if (root.right != null)
                str += "()";
            if (root.right != null)
                str += "(" + Tree2str(root.right) + ")";
            return str;
        }
    }
}
