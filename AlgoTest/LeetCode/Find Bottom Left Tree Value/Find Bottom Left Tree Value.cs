using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_Bottom_Left_Tree_Value;

public class Find_Bottom_Left_Tree_Value
{
    public int FindBottomLeftValue(TreeNode root)
    {
        TreeNode mostLeftNode = null;
        var level = new Queue<TreeNode>();

        level.Enqueue(root);
            
        while(level.Count != 0)
        {
            var currentLevelCount = level.Count;
            mostLeftNode = level.Peek();

            do
            {
                var currentNode = level.Dequeue();

                if (currentNode.left != null)
                    level.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    level.Enqueue(currentNode.right);
            }
            while (--currentLevelCount > 0);
        }

        return mostLeftNode.val;
    }
}