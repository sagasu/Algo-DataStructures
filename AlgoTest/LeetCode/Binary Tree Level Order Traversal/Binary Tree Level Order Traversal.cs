using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Binary_Tree_Level_Order_Traversal
{
    internal class Binary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            var res = new List<IList<int>>();

            if (root == null)
                return res;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                var row = new List<int>();

                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    row.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                res.Add(row);
            }

            return res;
        }
    }
}
