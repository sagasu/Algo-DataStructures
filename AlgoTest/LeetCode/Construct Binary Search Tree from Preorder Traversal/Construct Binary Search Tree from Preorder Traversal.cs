using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Construct_Binary_Search_Tree_from_Preorder_Traversal
{
    class Construct_Binary_Search_Tree_from_Preorder_Traversal
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            var s = new Stack<(TreeNode n, int rank)>();
            var root = new TreeNode(preorder[0]);
            s.Push((root, int.MaxValue));

            for (var i = 1; i < preorder.Length; i++)
            {
                var n = new TreeNode(preorder[i]);
                // while we have to move up, pop out of stack
                while (s.Peek().rank < n.val)
                {
                    s.Pop();
                }

                var e = s.Peek();
                if (n.val <= e.n.val)
                {
                    // on the left child push with we push parent node value as rank
                    e.n.left = n;
                    s.Push((n, e.n.val));
                }
                else
                {
                    // on the right child we push with the rank value received from parent
                    e.n.right = n;
                    s.Push((n, e.rank));
                }
            }

            return root;
        }
    }
}
