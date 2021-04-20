using System;
using System.Collections.Generic;


namespace AlgoTest.LeetCode.N_ary_Tree_Preorder_Traversal
{
    public class N_ary_Tree_Preorder_Traversal
    {
        public IList<int> Preorder(Node root)
        {
            IList<int> traverse = new List<int>();

            void TraversePreorder(Node node)
            {
                if (node == null) return;

                traverse.Add(node.val);

                foreach (var nodeChild in node.children)
                {
                    TraversePreorder(nodeChild);
                }
            }
            TraversePreorder(root);
            return traverse;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
