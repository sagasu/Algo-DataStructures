using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Flatten_Binary_Tree_to_Linked_List
{
    internal class Flatten_Binary_Tree_to_Linked_List
    {
        public void Flatten(TreeNode root)
        {
            while (root != null)
            {
                if (root.left != null)
                {
                    if (root.right == null)
                    {
                        root.right = root.left;
                    }
                    else
                    {
                        var nextRight = root.right;
                        root.right = root.left;
                        var cur = root.right;
                        while (cur.right != null)
                        {
                            cur = cur.right;
                        }

                        cur.right = nextRight;
                    }
                    root.left = null;
                }
                root = root.right;
            }
        }
}
