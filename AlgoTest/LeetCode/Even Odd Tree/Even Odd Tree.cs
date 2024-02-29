using System.Collections.Generic;

namespace AlgoTest.LeetCode.Even_Odd_Tree;

public class Even_Odd_Tree
{
    public bool IsEvenOddTree(TreeNode root) {
        var nodes = new Queue<TreeNode>(new TreeNode[]{root});
        var level = 0;
        
        while (nodes.Count > 0)
        {
            var levelNodesCount = nodes.Count;
            var previousVal = 0;
            for (var i=0; i<levelNodesCount; i++)
            {
                var curNode = nodes.Dequeue();
                
                if (level%2 == 0)
                {  
                    if (curNode.val%2 == 0)
                        return false;
                    if (previousVal != 0 && curNode.val <= previousVal)
                        return false;
                }
                else
                {
                    if (curNode.val%2 != 0)
                        return false;
                    if (previousVal != 0 && curNode.val >= previousVal)
                        return false;
                }
                previousVal = curNode.val;
                
                if (curNode.left != null)
                    nodes.Enqueue(curNode.left);
                if (curNode.right != null)
                    nodes.Enqueue(curNode.right);
            }
            level++;
        }

        return true;
    }
}