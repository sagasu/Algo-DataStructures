using System.Collections.Generic;

namespace AlgoTest.LeetCode.Kth_Largest_Sum_in_a_Binary_Tree;

public class Kth_Largest_Sum_in_a_Binary_Tree
{
    public long KthLargestLevelSum(TreeNode root, int k) {
        var list = new List<long>();
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while(queue.Count > 0) {
            long sum = 0;
            var count = queue.Count;
            for(int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                sum += node.val;

                if(node.left != null)
                    queue.Enqueue(node.left);

                if(node.right != null)
                    queue.Enqueue(node.right);
            }

            list.Add(sum);
        }

        list.Sort();
        return list.Count < k ? -1 : list[^k];
    }
}