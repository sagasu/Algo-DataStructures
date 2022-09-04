using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Vertical_Order_Traversal_of_a_Binary_Tree
{
    internal class Vertical_Order_Traversal_of_a_Binary_Tree
    {
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var sd = new SortedDictionary<int, IList<int[]>>();

            Traverse(sd, root, 0, 0);

            var res = new List<IList<int>>();

            foreach (var v in sd.Values) res.Add(v.OrderBy(b => b[1]).ThenBy(c => c[0]).Select(a => a[0]).ToList());

            return res;
        }

        private void Traverse(SortedDictionary<int, IList<int[]>> sd, TreeNode node, int pos, int depth)
        {
            if (node == null) return;

            if (!sd.ContainsKey(pos)) sd[pos] = new List<int[]>();

            sd[pos].Add(new[] { node.val, depth });

            Traverse(sd, node.left, pos - 1, depth + 1);

            Traverse(sd, node.right, pos + 1, depth + 1);
        }
    }
}
