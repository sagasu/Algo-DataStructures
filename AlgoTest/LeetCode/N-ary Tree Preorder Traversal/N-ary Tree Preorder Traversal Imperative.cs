using System;
using System.Collections.Generic;


namespace AlgoTest.LeetCode.N_ary_Tree_Preorder_Traversal
{
    public class N_ary_Tree_Preorder_Traversal_Imperative
    {
        public IList<int> Preorder(Node root)
        {
            IList<int> traverse = new List<int>();

            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.TryPop(out Node node))
            {
                traverse.Add(node.val);
                for(var i = node.children.Count-1; i>=0;i--)
                {
                    stack.Push(node.children[i]);
                }
            }

            return traverse;
        }
    }
}
