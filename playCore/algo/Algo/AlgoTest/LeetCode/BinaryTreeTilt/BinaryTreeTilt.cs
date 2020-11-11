using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.BinaryTreeTilt
{
    public class BinaryTreeTilt
    {
        public void Test()
        {

        }

        List<int> tree = new List<int>();

        public int FindTilt(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                //if(node.left != )
            }

            return 0;
        }

        private void InOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                tree.Add(0);
                return;
            }

            tree.Add(root.val);

            InOrderTraversal(root.left);
            InOrderTraversal(root.right);

        }
    }
}
