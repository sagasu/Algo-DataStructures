using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.N_ary_Tree_Postorder_Traversal;

public class N_ary_Tree_Postorder_Traversal
{
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    public IList<int> Postorder(Node root) {
        if (root == null) return new List<int>();
        var result = new List<int> { root.val };
        return root.children == null
            ? result
            : root.children.SelectMany(Postorder).Concat(result).ToList();
    }
}