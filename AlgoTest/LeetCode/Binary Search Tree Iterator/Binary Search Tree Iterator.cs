using System.Collections.Generic;

namespace AlgoTest.LeetCode.Binary_Search_Tree_Iterator
{
    internal class BSTIterator
    {
        private readonly Queue<TreeNode> _queue;

        public BSTIterator(TreeNode root)
        {
            _queue = new Queue<TreeNode>();
            DFS(root, _queue);

        }
        private void DFS(TreeNode node, Queue<TreeNode> q)
        {
            if (node == null) return;

            DFS(node.left, q);
            q.Enqueue(node);
            DFS(node.right, q);
        }

        public int Next()
        {
            return _queue.Dequeue().val;
        }

        public bool HasNext()
        {
            if (_queue.Count > 0) return true;
            
            return false;
        }
    }
}
