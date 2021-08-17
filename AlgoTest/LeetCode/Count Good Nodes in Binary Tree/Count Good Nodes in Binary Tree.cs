using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Count_Good_Nodes_in_Binary_Tree
{
    class Count_Good_Nodes_in_Binary_Tree
    {
        public int GoodNodes(TreeNode root)
        {
            if (root == null) { return 0; }

            var goodNodeCount = 0;
            Traverse(root, root.val, ref goodNodeCount);
            return goodNodeCount;
        }

        private void Traverse(TreeNode node, int maxPathValue, ref int goodNodeCount)
        {
            if (node == null) { return; }

            if (maxPathValue <= node.val) { maxPathValue = node.val; goodNodeCount++; }

            Traverse(node.left, maxPathValue, ref goodNodeCount);
            Traverse(node.right, maxPathValue, ref goodNodeCount);
        }
    }
}
