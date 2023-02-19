using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Binary_Tree_Zigzag_Level_Order_Traversal
{
    public class Binary_Tree_Zigzag_Level_Order_Traversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> res = new();
            if (root == null) return res;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var isReverse = false; 
            
            while (queue.Any())
            {
                var n = queue.Count;
                List<int> levelValues = new(); 

                for (int i = 0; i < n; i++)
                {
                    var curr = queue.Dequeue();
                    levelValues.Add(curr.val);
                    if (curr.left is not null) queue.Enqueue(curr.left);
                    if (curr.right is not null) queue.Enqueue(curr.right);
                }

                if (isReverse) levelValues.Reverse();

                res.Add(levelValues); 
                isReverse = !isReverse;
            }

            return res;
        }
    }
}
