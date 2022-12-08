using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Leaf_Similar_Trees
{
    internal class Leaf_Similar_Trees
    {
        List<int> leaves1 = new List<int>();
        List<int> leaves2 = new List<int>();

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            dfs(root1, leaves1);
            dfs(root2, leaves2);

            if (leaves1.Count != leaves2.Count) return false;

            return leaves1.SequenceEqual(leaves2);
        }


        public void dfs(TreeNode node, List<int> leaves)
        {
            if (node == null) return;
            if (node.left == null && node.right == null)
            {
                leaves.Add(node.val);
            }
            dfs(node.left, leaves);
            dfs(node.right, leaves);

        }
    }
}
